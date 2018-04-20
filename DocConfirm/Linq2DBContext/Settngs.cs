using System.Linq;
using System.Collections.Generic;
using LinqToDB.Configuration;

namespace DocConfirm.Linq2DBContext
{
	public class ConnectionStringSettings : IConnectionStringSettings
	{
		public string ConnectionString { get; set; }
		public string Name { get; set; }
		public string ProviderName { get; set; }
		public bool IsGlobal => false;
	}

	public class DocConfirmSettings : ILinqToDBSettings
	{
		public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();

		public string DefaultConfiguration => "DocConfirm";
		public string DefaultDataProvider => "MySql.Data.MySqlClient";

		public IEnumerable<IConnectionStringSettings> ConnectionStrings
		{
			get
			{
				yield return
					new ConnectionStringSettings
					{
						Name = "DocConfirm",
						ProviderName = "MySql.Data.MySqlClient",
						ConnectionString = "Server=localhost;Port=3306;Database=docconfirm;Uid=root;Pwd=12345678;charset=utf8;SslMode=none;"
					};
			}
		}
	}
}
