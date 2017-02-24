using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class DeleteBeeBreed : ICommandAsync
	{
		public BeeBreed breed { get; private set;}

		public DeleteBeeBreed(BeeBreed breed)
		{
			this.breed = breed;
		}
	}
}
