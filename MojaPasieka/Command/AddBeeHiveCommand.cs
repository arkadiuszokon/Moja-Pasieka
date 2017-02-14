using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class AddBeeHiveCommand : ICommand
	{
		public readonly BeeHive beeHive; 

		public AddBeeHiveCommand(BeeHive beeHive)
		{
			this.beeHive = beeHive;
		}
	}
}
