using Dapper;
using System.Data.SqlClient;
using System.IO.Compression;

namespace Orders.Web
{
	public class DbManager
	{
		private readonly string _masterDb;
		private readonly string _dbName;

		public DbManager(IConfiguration configuration)
		{
			string db = configuration.GetConnectionString("OrdersDb") ?? "";
			SqlConnectionStringBuilder bldr = new SqlConnectionStringBuilder(db);
			_dbName = bldr.InitialCatalog;
			bldr.InitialCatalog = "master";
			_masterDb = bldr.ToString();
		}

		public void CheckDb()
		{


			using (SqlConnection cn = new SqlConnection(_masterDb))
			{
				cn.Open();

				int? temp = cn.ExecuteScalar<int?>($"SELECT 1 FROM sys.databases WHERE name='{_dbName}'");

				if (temp == null)
				{
					string sql = GetAttachSql();

					cn.Execute(sql);
				}
			}
		}
		

		private string GetAttachSql()
		{
			string root = Path.GetDirectoryName(Environment.CurrentDirectory);

			string db_dir = Path.Join(root, "Database");
			string[] flst = Directory.GetFiles(db_dir);
			string zip = flst.Single(t => t.EndsWith($"{_dbName}.zip", StringComparison.OrdinalIgnoreCase));

			ZipFile.ExtractToDirectory(zip, db_dir, true);
			
			string mdf_path = flst.Single(t => t.EndsWith($"{_dbName}.mdf", StringComparison.OrdinalIgnoreCase));
			string ldf_path = flst.Single(t => t.EndsWith($"{_dbName}_log.ldf", StringComparison.OrdinalIgnoreCase));

			string sql = $"CREATE DATABASE {_dbName} ON\r\n(FILENAME='{mdf_path}'),\r\n(FILENAME='{ldf_path}')\r\nFOR ATTACH";

			return sql;
		}
	}
}
