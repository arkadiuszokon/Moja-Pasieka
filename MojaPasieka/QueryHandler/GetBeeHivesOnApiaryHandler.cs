using System;
using SQLite;
using MojaPasieka.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace MojaPasieka.cqrs
{
	public class GetBeeHivesOnApiaryHandler : QueryHandlerBase, IQueryHandler<GetBeeHivesOnApiary, List<BeeHive>>
	{

		public List<BeeHive> Execute(GetBeeHivesOnApiary query)
		{
			return Connection.Query<BeeHive>("SELECT * FROM tb_beehive WHERE bh_ap_id = " + query.ApiaryId.ToString());
		}
	}
}
