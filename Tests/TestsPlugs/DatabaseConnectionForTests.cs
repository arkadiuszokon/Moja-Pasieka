using System;
using System.IO;
using MojaPasieka.Startup;
using Autofac;
namespace Tests
{
	public class DatabaseConnectionForTests : IStartupTask
	{
		public void Execute(ContainerBuilder builder)
		{
			string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "databasetest.db");
			var conn = new SQLite.SQLiteConnection(path, true);
			builder.RegisterInstance<SQLite.SQLiteConnection>(conn);
		}
	}
}
