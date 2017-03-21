using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class SaveQueenBee : ICommandAsync
	{
		public QueenBee Queen { get; protected set; }

		public SaveQueenBee(QueenBee queen)
		{
			this.Queen = queen;
		}
	}
}
