using System;
using MojaPasieka.DataModel;
namespace MojaPasieka.cqrs
{
	public class GetColonyInBeeHive : IQuery<BeeColony>
	{
		public int BeeHiveID { get; protected set; }

		public GetColonyInBeeHive(int beeHiveID)
		{
			this.BeeHiveID = beeHiveID;
		}

	}
}
