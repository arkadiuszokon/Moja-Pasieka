using System;
using System.Collections.Generic;
using SQLite;
using SQLitePCL;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class GetBeeHivesListHandler : QueryHandlerBase, IQueryHandler<GetBeeHivesList, List<BeeHivesListItem>>
	{

		public List<BeeHivesListItem> Execute(GetBeeHivesList query)
		{
			return Connection.Query<BeeHivesListItem>("SELECT * FROM tb_beehive LEFT JOIN tb_beecolony ON bh_id = bc_bh_id WHERE bh_ap_id = ?", query.ApiaryId);
		}
	}
}
