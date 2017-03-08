using System;
using SQLite;
using MojaPasieka.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace MojaPasieka.cqrs
{
	public class GetBeeHivesOnApiaryHandler :IQueryHandler<GetBeeHivesOnApiary, List<BeeHive>>
	{
		protected SQLiteConnection _database;

		public GetBeeHivesOnApiaryHandler(SQLiteConnection database)
		{
			_database = database;
		}

		public List<BeeHive> Execute(GetBeeHivesOnApiary query)
		{
			return _database.Query<BeeHive>("SELECT * FROM tb_beehive WHERE bh_ap_id = " + query.ApiaryId.ToString());
		}
	}
}
