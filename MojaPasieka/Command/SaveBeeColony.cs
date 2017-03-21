using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class SaveBeeColony : ICommandAsync
	{
		public BeeColony Colony { get; protected set; }
		
		public SaveBeeColony(BeeColony colony)
		{
			this.Colony = colony;
		}
	}
}
