using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class GetColonyInBeeHiveHandler : QueryHandlerBase, IQueryHandler<GetColonyInBeeHive, BeeColony>
	{
		public BeeColony Execute(GetColonyInBeeHive query)
		{
			return Connection.FindWithQuery<BeeColony>("SELECT * FROM tb_beecolony WHERE bc_bh_id = ?", query.BeeHiveID);
		}
	}
}
