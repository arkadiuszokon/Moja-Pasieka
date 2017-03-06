using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class AddBeeHive : ICommandAsync
	{
		public BeeHive beeHive { get; protected set; }

		public AddBeeHive(BeeHive beeHive)
		{
			this.beeHive = beeHive;
		}
	}
}
