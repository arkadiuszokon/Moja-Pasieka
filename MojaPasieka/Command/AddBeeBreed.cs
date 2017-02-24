using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class AddBeeBreed : ICommandAsync
	{
		public BeeBreed breed { get; private set; }

		public AddBeeBreed(BeeBreed breed)
		{
			this.breed = breed;
		}
	}
}
