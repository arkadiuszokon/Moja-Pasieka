using System;
using MojaPasieka.DataModel;
using SQLite;

namespace MojaPasieka.cqrs
{
	public class GetNumOfRowsInTableHandler : QueryHandlerBase, IQueryHandler<GetNumOfRowsInTable, int>
	{

		public int Execute(GetNumOfRowsInTable query)
		{
			return Connection.ExecuteScalar<int>("SELECT COUNT(*) FROM " + DataModelBase.GetTableName(query.dataModel));
		}
	}
}
