using System;
using System.IO;
using System.Diagnostics;
using inWarehouseAndroid.Droid;
using MojaPasieka.DataModel;
using SQLite.Net.Async;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_Android))]
namespace inWarehouseAndroid.Droid
{
	public class DatabaseConnection_Android : IDatabaseConnection
	{
		public SQLiteAsyncConnection DBConnection()
		{
			var dbName = "database.db3";
			var path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), dbName);
			var sqliteConn = new SQLite.Net.SQLiteConnectionWithLock(new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid(), new SQLite.Net.SQLiteConnectionString(path, true));
			var connection = new SQLiteAsyncConnection(() => sqliteConn);
			return connection;
		}
	}
}
