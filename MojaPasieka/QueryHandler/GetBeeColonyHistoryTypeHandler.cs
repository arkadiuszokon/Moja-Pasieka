using System;
using MojaPasieka.DataModel;
namespace MojaPasieka.cqrs
{
	public class GetBeeColonyHistoryTypeHandler : QueryHandlerBase, IQueryHandler<GetBeeColonyHistoryType, BeeColonyHistoryType>
	{

		public BeeColonyHistoryType Execute(GetBeeColonyHistoryType query)
		{
			return Connection.Query<BeeColonyHistoryType>("SELECT * FROM tb_beecolonyhistorytype WHERE bcht_main = " + ((int)query.Type).ToString())[0];
		}
	}
}
