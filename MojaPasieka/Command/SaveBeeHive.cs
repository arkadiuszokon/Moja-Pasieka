using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class SaveBeeHive : ICommandAsync
	{
		public BeeHive BeeHive { get; protected set; }

		public SaveBeeHive(BeeHive beeHive)
		{
			this.BeeHive = beeHive;
		}
	}
}
