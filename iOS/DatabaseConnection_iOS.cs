using System;
using MojaPasieka.iOS;
using MojaPasieka.DataModel;
using SQLite;
using System.IO;

[assembly: Xamarin.Forms.Dependency (typeof (DatabaseConnection_iOS))]
namespace MojaPasieka.iOS
{
	public class DatabaseConnection_iOS : IDatabaseConnection
	{
		public SQLiteConnection DBConnection ()
		{
			string docFolder = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string libFolder = Path.Combine (docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            string dbPath = Path.Combine(libFolder, "database.db");

			var sqliteconnection = new SQLiteConnection (dbPath);
			return sqliteconnection;
		}

	}
}
