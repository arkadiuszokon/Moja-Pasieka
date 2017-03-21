using System;
using MojaPasieka.DataModel;
using System.Collections.Generic;

namespace MojaPasieka.cqrs
{
	public class GetBeeHiveBodies : IQuery<List<BeeHiveBody>>
	{
		public int BeeHiveID { get; protected set; }

		public GetBeeHiveBodies(int beeHiveID)
		{
			this.BeeHiveID = beeHiveID;
		}
	}
}
