using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class SaveBeeBreed : ICommandAsync
	{
		public BeeBreed Breed { get; private set; }

		public SaveBeeBreed(BeeBreed breed)
		{
			this.Breed = breed;
		}
	}
}
