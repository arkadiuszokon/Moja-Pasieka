using System;
using System.Collections.Generic;
using System.Linq;
using MojaPasieka.DataModel;
using SQLite;

namespace MojaPasieka.cqrs
{
	public class GetFullListOfHandler : IQueryHandler<GetFullListOf, List<object>> 
	{
		private SQLiteConnection _database;

		public GetFullListOfHandler(SQLiteConnection database)
		{
			_database = database;
		}

		public List<object> Execute(GetFullListOf query)
		{
			return _database.Query(new TableMapping(query.dataModel), "SELECT * FROM " + DataModelBase.GetTableName(query.dataModel));
		}
	}
}
