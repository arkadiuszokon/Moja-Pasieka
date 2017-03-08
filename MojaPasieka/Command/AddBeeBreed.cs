using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class AddBeeBreed : ICommandAsync
	{
		public BeeBreed Breed { get; private set; }

		public AddBeeBreed(BeeBreed breed)
		{
			this.Breed = breed;
		}
	}
}
