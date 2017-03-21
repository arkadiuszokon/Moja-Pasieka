using System;
using MojaPasieka.DataModel;
using System.Collections.Generic;

namespace MojaPasieka.cqrs
{
	public class GetFramesInBeeHiveBodyHandler : QueryHandlerBase, IQueryHandler<GetFramesInBeeHiveBody, List<Frame>>
	{
		public List<Frame> Execute(GetFramesInBeeHiveBody query)
		{
			return Connection.Query<Frame>("SELECT * FROM tb_frame WHERE fr_bhb_id = ?", query.BodyID);
		}
	}
}
