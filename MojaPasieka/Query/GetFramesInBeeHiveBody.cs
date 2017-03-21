using System;
using MojaPasieka.DataModel;
using System.Collections.Generic;

namespace MojaPasieka.cqrs
{
	public class GetFramesInBeeHiveBody : IQuery<List<Frame>>
	{
		public int BodyID { get; protected set; }

		public GetFramesInBeeHiveBody(int bodyID)
		{
			this.BodyID = bodyID;
		}
	}
}
