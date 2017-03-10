using System;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class AddQueenBee : ICommandAsync
	{
		public QueenBee Queen { get; protected set; }

		public AddQueenBee(QueenBee queen)
		{
			this.Queen = queen;
		}
	}
}
