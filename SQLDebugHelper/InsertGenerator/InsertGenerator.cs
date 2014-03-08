using System;
using System.Text;
using System.Data;

namespace SQLDebugHelper
{
	public static class InsertGenerator
	{
		private static char tab = (char)9;
		private static char space = (char)32;
		private static DataTable fieldSettings = null;

		public static string GenerateInserts(string[] inputLines)
		{
			//Get Table Name and fields
			bool useSQL2008Syntax = true;
			bool useIfNotExists = false;
            bool useIdentityInsert = false;
			String tableName = string.Empty;
			String[] fields = inputLines[0].Split(tab);

			#region Determine what fields to include
			DataColumn column = null;

			fieldSettings = new DataTable("FieldSettings");
			column = new DataColumn("FieldName");
			fieldSettings.Columns.Add(column);
			column = new DataColumn("Include", typeof(bool));
			fieldSettings.Columns.Add(column);
			column = new DataColumn("NoDelimiter", typeof(bool));
			fieldSettings.Columns.Add(column);

			DataRow row;

			foreach (string fieldname in fields)
			{
				row = fieldSettings.NewRow();
				row.ItemArray = new object[] { fieldname, true, false };
				fieldSettings.Rows.Add(row);
			}

			using (FieldInfo fieldInfoDialog = new FieldInfo())
			{
				fieldInfoDialog.FieldData = fieldSettings;
				fieldInfoDialog.ShowDialog();

				if (fieldInfoDialog.DialogResult == System.Windows.Forms.DialogResult.OK)
				{
					tableName = fieldInfoDialog.TableName;
					useSQL2008Syntax = fieldInfoDialog.UseSQL2008Syntax;
					useIfNotExists = fieldInfoDialog.UseIfNotExists;
                    useIdentityInsert = fieldInfoDialog.UseIdentityInsert;
				}
				else
				{
					return "Generation Insert operation cancelled.";
				}
			}

			#endregion Determine what fields to include

			StringBuilder sqlOutput = new StringBuilder();

			string notExistsTemplate = "IF NOT EXISTS (SELECT * FROM [" + tableName + "] where {CONDITIONS})\nBEGIN\n\t{INSERT}\n\t{VALUES}\nEND\n";
			string insertTemplate = "INSERT INTO [" + tableName + "] ({FIELDS})";
			string valueTemplate = "VALUES ({values})";
            string identityInsertTemplate = "SET IDENTITY_INSERT [" + tableName + "] {TOGGLE};";

            if (useIdentityInsert)
            {
                sqlOutput.AppendLine(identityInsertTemplate.Replace("{TOGGLE}", "ON"));
            }

			if (useIfNotExists)
			{
				useSQL2008Syntax = !useIfNotExists;
			}

			string insertString = insertTemplate.Replace("{FIELDS}", BuildInsertFields());
			string notExistsString = notExistsTemplate.Replace("{INSERT}", insertString);

			if (useSQL2008Syntax)
			{
				sqlOutput.AppendLine(insertString);
			}

			#region Values
			int lineCount = 0;

			foreach (string dataline in inputLines)
			{
				lineCount ++;
				if (lineCount > 1)
				{
					string valueString = valueTemplate.Replace("{values}", BuildValueList(dataline));
                    
					if (useSQL2008Syntax)
					{
                        if (lineCount > 2)
                        {
                            valueString = valueString.Remove(0, 7);
                        }

						valueString += ",";

						sqlOutput.AppendLine(valueString);

						if (lineCount % 999 == 0)       // only 1000 inserts per statement
						{
							sqlOutput.Remove(sqlOutput.Length - 3, 1); //remove last comma
							sqlOutput.Append(insertString);
						}
					}
					else
					{
						if (useIfNotExists)
						{
							sqlOutput.AppendLine(notExistsString.Replace("{CONDITIONS}", BuildNotExistsConditions(dataline))
																.Replace("{VALUES}", valueString));
						}
						else
						{
							sqlOutput.AppendLine(insertString);
							sqlOutput.AppendLine(valueString);
						}
					}
				}
			}
			#endregion Values

			if (useSQL2008Syntax)
			{
				sqlOutput.Remove(sqlOutput.Length - 3, 1); //remove last comma
			}

            if (useIdentityInsert)
            {
                sqlOutput.AppendLine(identityInsertTemplate.Replace("{TOGGLE}", "OFF"));
            }

			return sqlOutput.ToString();
		}

		private static string BuildInsertFields()
		{
			StringBuilder sbFields = new StringBuilder();

			foreach (DataRow fieldRow in fieldSettings.Rows)
			{
				if (fieldRow.Field<bool>("Include"))
				{
					//sbFields.AppendLine(tab + fieldRow.Field<String>("FieldName") + ",");
					sbFields.Append(space + fieldRow.Field<String>("FieldName") + ",");
				}
			}

			sbFields.Remove(sbFields.Length - 1, 1); // remove last comma

			return sbFields.ToString();
		}

		private static string BuildValueList(string dataline)
		{
			int fieldCount = 0;
			StringBuilder sbValues = new StringBuilder();

			string[] dataFields = dataline.Split(tab);

			foreach (DataRow fieldRow in fieldSettings.Rows)
			{
				if (fieldRow.Field<bool>("Include"))
				{
					if (fieldRow.Field<bool>("NoDelimiter"))
					{
						sbValues.Append(dataFields[fieldCount] + ", ");
					}
					else
					{
						if (dataFields[fieldCount].ToUpper().Equals("NULL"))
						{
							sbValues.Append(dataFields[fieldCount] + ", ");
						}
						else
						{
							sbValues.Append("'" + dataFields[fieldCount] + "', ");
						}
					}
				}

				fieldCount++;
			}

			sbValues.Remove(sbValues.Length - 2, 2); //remove last comma

			return sbValues.ToString();
		}

		private static string BuildNotExistsConditions(string dataline)
		{
			int fieldCount = 0;
			StringBuilder sbConditions = new StringBuilder();

			string[] dataFields = dataline.Split(tab);

			foreach (DataRow fieldRow in fieldSettings.Rows)
			{
				if (fieldRow.Field<bool>("Include"))
				{
					sbConditions.Append(space + fieldRow.Field<String>("FieldName"));

					if (fieldRow.Field<bool>("NoDelimiter"))
					{
						sbConditions.Append("=" + dataFields[fieldCount] + "and ");
					}
					else
					{
						if (dataFields[fieldCount].ToUpper().Equals("NULL"))
						{
							sbConditions.Append(" is " + dataFields[fieldCount] + " and ");
						}
						else
						{
							sbConditions.Append("='" + dataFields[fieldCount] + "' and ");
						}
					}
				}

				fieldCount++;
			}

			sbConditions.Remove(sbConditions.Length - 4, 3); //remove last comma

			return sbConditions.ToString();
		}

	}
}
