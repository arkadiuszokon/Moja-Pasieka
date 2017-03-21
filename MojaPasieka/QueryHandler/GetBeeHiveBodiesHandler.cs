using System;
using MojaPasieka.DataModel;
using System.Collections.Generic;

namespace MojaPasieka.cqrs
{
	public class GetBeeHiveBodiesHandler : QueryHandlerBase, IQueryHandler<GetBeeHiveBodies, List<BeeHiveBody>>
	{
		public List<BeeHiveBody> Execute(GetBeeHiveBodies query)
		{
			return Connection.Query<BeeHiveBody>("SELECT * FROM tb_beehivebody where bhb_bh_id = ?", query.BeeHiveID);
		}
	}
}
