using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MojaPasieka.cqrs;
using MojaPasieka.DataModel;
using SQLite;

namespace MojaPasieka
{
	public class GetListOfBeeHivesHandler : IQueryHandler<GetListOfBeeHives, List<BeeHive>>
	{

		private SQLiteConnection _database;

		public GetListOfBeeHivesHandler(SQLiteConnection database)
		{
			_database = database;
		}

		public List<BeeHive> Execute(GetListOfBeeHives query)
		{
			return _database.Query<BeeHive>("SELECT * FROM tb_ul_beehive");
		}
	}
}
