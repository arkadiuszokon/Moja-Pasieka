using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class AddApiary : ICommandAsync
	{
		public Apiary apiary {get; private set;}

		public AddApiary(Apiary apiary)
		{
			this.apiary = apiary;
		}
	}
}
