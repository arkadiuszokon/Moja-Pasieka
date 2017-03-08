using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class DeleteBeeBreed : ICommandAsync
	{
		public BeeBreed Breed { get; private set;}

		public DeleteBeeBreed(BeeBreed breed)
		{
			this.Breed = breed;
		}
	}
}
