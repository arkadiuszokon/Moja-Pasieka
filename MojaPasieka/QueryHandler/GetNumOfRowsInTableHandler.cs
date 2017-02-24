using System;
using MojaPasieka.DataModel;
using SQLite;

namespace MojaPasieka.cqrs
{
	public class GetNumOfRowsInTableHandler : IQueryHandler<GetNumOfRowsInTable, int>
	{

		private SQLiteConnection _database;

		public GetNumOfRowsInTableHandler(SQLiteConnection database)
		{
			_database = database;
		}


		public int Execute(GetNumOfRowsInTable query)
		{
			return _database.ExecuteScalar<int>("SELECT COUNT(*) FROM " + DataModelBase.GetTableName(query.dataModel));
		}
	}
}
