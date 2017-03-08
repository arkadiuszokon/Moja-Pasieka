using System;
using System.Collections.Generic;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class GetBeeHivesOnApiary :IQuery<List<BeeHive>>
	{
		public int ApiaryId { get; protected set; }

		public GetBeeHivesOnApiary(int apiaryId)
		{
			this.ApiaryId = apiaryId;
		}
	}
}
