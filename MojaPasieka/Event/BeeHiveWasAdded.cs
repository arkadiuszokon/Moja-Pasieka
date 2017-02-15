using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class BeeHiveWasAdded : IEvent
	{
		public readonly BeeHive beeHive;

		public BeeHiveWasAdded(BeeHive beeHive)
		{
			this.beeHive = beeHive;
		}
	}
}
