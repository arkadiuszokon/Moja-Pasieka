using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class AddBeeColony : ICommandAsync
	{
		public BeeColony Colony { get; protected set; }
		
		public AddBeeColony(BeeColony colony)
		{
			this.Colony = colony;
		}
	}
}
