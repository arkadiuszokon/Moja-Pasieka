using System;
using System.Collections.Generic;
using System.Linq;
using MojaPasieka.DataModel;
using SQLite;

namespace MojaPasieka.cqrs
{
	public class GetFullListOfHandler : QueryHandlerBase, IQueryHandler<GetFullListOf, List<object>> 
	{

		public List<object> Execute(GetFullListOf query)
		{
			return Connection.Query(new TableMapping(query.dataModel), "SELECT * FROM " + DataModelBase.GetTableName(query.dataModel));
		}
	}
}
