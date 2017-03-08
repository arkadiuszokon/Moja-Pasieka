using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class AddBeeHive : ICommandAsync
	{
		public BeeHive BeeHive { get; protected set; }

		public AddBeeHive(BeeHive beeHive)
		{
			this.BeeHive = beeHive;
		}
	}
}
