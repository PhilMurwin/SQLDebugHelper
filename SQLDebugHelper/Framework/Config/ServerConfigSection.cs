using System.Configuration;

namespace Framework.Config
{
	/* Sample:
	  	<ServerConfig>
	  		<Servers>
				<Server
					DBServer="server"
					database="db"
					username="user"
					password="password"
					timeout="120"
				/>
			</Servers>
		</ServerConfig>
	 * */

	/* The following articles were the basis for the classes in this file.
	 * They were by far the best resource I could find to explain custom config sections
	 * http://www.codeproject.com/Articles/16466/Unraveling-the-Mysteries-of-NET-2-0-Configuration
	 * http://www.codeproject.com/Articles/16724/Decoding-the-Mysteries-of-NET-2-0-Configuration
	 * */

	public class ServerConfigSection : ConfigurationSection
	{
		[ConfigurationProperty("Servers", IsRequired = true)]
		public ServerElementCollection Server
		{
			get
			{
				return this["Servers"] as ServerElementCollection;
			}
			set
			{
				this["Servers"] = value;
			}
		}

		public ServerElement FindProfile(string profileName)
		{
			ServerElement result = null;

			foreach (ServerElement element in this.Server)
			{
				if (element.ProfileName == profileName)
				{
					result = element;
					break;
				}
			}

			return result;
		}
	}

	public class ServerElement : ConfigurationElement
	{
		[ConfigurationProperty("ProfileName", IsRequired = true)]
		public string ProfileName
		{
			get
			{
				return (string)this["ProfileName"];
			}
			set
			{
				this["ProfileName"] = value;
			}
		}

		[ConfigurationProperty("DBServer", IsRequired = true)]
		public string DBServer
		{
			get
			{
				return (string)this["DBServer"];
			}
			set
			{
				this["DBServer"] = value;
			}
		}

		[ConfigurationProperty("database", IsRequired = true)]
		public string database
		{
			get
			{
				return (string)this["database"];
			}
			set
			{
				this["database"] = value;
			}
		}

		[ConfigurationProperty("username")]
		public string username
		{
			get
			{
				return (string)this["username"];
			}
			set
			{
				this["username"] = value;
			}
		}

		[ConfigurationProperty("password")]
		public string password
		{
			get
			{
				return (string)this["password"];
			}
			set
			{
				this["password"] = value;
			}
		}

		[ConfigurationProperty("timeout", IsRequired = true)]
		public string timeout
		{
			get
			{
				return (string)this["timeout"];
			}
			set
			{
				this["timeout"] = value;
			}
		}

		[ConfigurationProperty("logging", IsRequired = false)]
		public string logging
		{
			get
			{
				//if null or empty return 0, else return string
				return (string.IsNullOrEmpty(this["logging"].ToString()) ? "0" : this["logging"].ToString());
			}
			set
			{
				this["logging"] = value;
			}
		}
	}

	[ConfigurationCollection(typeof(ServerElement), AddItemName = "Server",
		CollectionType = ConfigurationElementCollectionType.BasicMap)]
	public class ServerElementCollection : ConfigurationElementCollection
	{
		#region Properties
		public override ConfigurationElementCollectionType CollectionType
		{
			get
			{
				return ConfigurationElementCollectionType.BasicMap;
			}
		}

		protected override string ElementName
		{
			get { return "Server"; }
		}
		#endregion Properties

		#region Indexers
		public ServerElement this[int index]
		{
			get
			{
				return base.BaseGet(index) as ServerElement;
			}
			set
			{
				if (base.BaseGet(index) != null)
				{
					base.BaseRemoveAt(index);
				}
				base.BaseAdd(index, value);
			}
		}

		#endregion Indexers

		#region Overrides
		protected override object GetElementKey(ConfigurationElement element)
		{
			return (element as ServerElement);
		}

		protected override ConfigurationElement CreateNewElement()
		{
			return new ServerElement();
		}
		#endregion Overrides


	}
}