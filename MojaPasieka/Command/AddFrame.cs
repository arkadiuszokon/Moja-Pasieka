using System;
using MojaPasieka.DataModel;
namespace MojaPasieka.cqrs
{
	public class AddFrame : ICommandAsync
	{
		public Frame Frame { get; protected set; }
		
		public AddFrame(Frame frame)
		{
			this.Frame = frame;
		}
	}
}
