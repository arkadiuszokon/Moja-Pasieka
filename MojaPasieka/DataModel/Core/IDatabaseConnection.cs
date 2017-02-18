using System;
using SQLite;
using SQLite;

namespace MojaPasieka.DataModel
{
	public interface IDatabaseConnection
	{
		SQLiteAsyncConnection DBConnection();
	}
}
