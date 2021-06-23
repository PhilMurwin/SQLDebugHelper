namespace SQLDebugHelper.Models
{
    public class SQLObjectColumnModel
    {
        public string Name { get; set; }
        public int ColumnID { get; set; }
        public string Type { get; set; }
        public bool IsNullable { get; set; }
    }
}
