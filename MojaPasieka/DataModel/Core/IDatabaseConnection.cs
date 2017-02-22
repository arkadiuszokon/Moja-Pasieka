using System;
using SQLite;


namespace MojaPasieka.DataModel
{
	public interface IDatabaseConnection
	{
		SQLiteConnection DBConnection();
	}
}
