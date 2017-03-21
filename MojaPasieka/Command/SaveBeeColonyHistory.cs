using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class SaveBeeColonyHistory : ICommandAsync
	{
		public BeeColonyHistory ColonyHistory { get; protected set; }

		public SaveBeeColonyHistory(BeeColonyHistory colonyHistory)
		{
			this.ColonyHistory = colonyHistory;
		}
	}
}
