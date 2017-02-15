using System;
using System.IO;
using System.Diagnostics;
using inWarehouseAndroid.Droid;
using MojaPasieka.DataModel;
using SQLite;
using SQLitePCL;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_Android))]
namespace inWarehouseAndroid.Droid
{
	public class DatabaseConnection_Android : IDatabaseConnection
	{
		public SQLiteAsyncConnection DBConnection()
		{
			var dbName = "database.db3";
			var path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), dbName);

			var connection = new SQLiteAsyncConnection(path, true);
			return connection;
		}
	}
}
