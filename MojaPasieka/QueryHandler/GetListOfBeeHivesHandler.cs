using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MojaPasieka.cqrs;
using MojaPasieka.DataModel;
using SQLite;

namespace MojaPasieka
{
	public class GetListOfBeeHivesHandler : IQueryHandlerAsync<GetListOfBeeHives, List<BeeHive>>
	{

		private SQLiteAsyncConnection _database;

		public GetListOfBeeHivesHandler(SQLiteAsyncConnection database)
		{
			_database = database;
		}

		public Task<List<BeeHive>> ExecuteAsync(GetListOfBeeHives query)
		{
			return _database.QueryAsync<BeeHive>("SELECT * FROM tb_ul_beehive");
		}
	}
}
