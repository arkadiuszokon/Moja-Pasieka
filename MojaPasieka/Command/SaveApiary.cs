using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class SaveApiary : ICommandAsync
	{
		public Apiary Apiary { get; private set; }

		public SaveApiary(Apiary apiary)
		{
			this.Apiary = apiary;
		}
	}
}
