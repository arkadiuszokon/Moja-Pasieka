using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class BeeHiveAddedEvent : IEvent
	{
		public readonly BeeHive beeHive;

		public BeeHiveAddedEvent(BeeHive beeHive)
		{
			this.beeHive = beeHive;
		}
	}
}
