using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class AddBeeColonyHistory : ICommandAsync
	{
		public BeeColonyHistory ColonyHistory { get; protected set; }

		public AddBeeColonyHistory(BeeColonyHistory colonyHistory)
		{
			this.ColonyHistory = colonyHistory;
		}
	}
}
