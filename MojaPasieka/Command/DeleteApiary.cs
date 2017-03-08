using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class DeleteApiary : ICommandAsync
	{
		public Apiary Apiary { get; private set; }

		public DeleteApiary(Apiary apiary)
		{
			this.Apiary = apiary;
		}
	}
}
