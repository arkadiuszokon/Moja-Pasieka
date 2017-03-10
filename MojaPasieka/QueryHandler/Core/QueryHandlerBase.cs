using System;
using SQLite;

namespace MojaPasieka.cqrs
{
	public class QueryHandlerBase
	{
		public SQLiteConnection Connection { get; set; }
	}
}
