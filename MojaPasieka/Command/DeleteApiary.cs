using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class DeleteApiary : ICommandAsync
	{
		public Apiary apiary { get; private set; }

		public DeleteApiary(Apiary apiary)
		{
			this.apiary = apiary;
		}
	}
}
