using System;
using SQLite;
using SQLite.Net.Async;

namespace MojaPasieka.DataModel
{
	public interface IDatabaseConnection
	{
		SQLiteAsyncConnection DBConnection();
	}
}
