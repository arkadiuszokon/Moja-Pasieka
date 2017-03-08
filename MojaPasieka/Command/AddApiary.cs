using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class AddApiary : ICommandAsync
	{
		public Apiary Apiary { get; private set; }

		public AddApiary(Apiary apiary)
		{
			this.Apiary = apiary;
		}
	}
}
