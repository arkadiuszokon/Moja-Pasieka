using System;
using MojaPasieka.DataModel;
namespace MojaPasieka.cqrs
{
	public class SaveFrame : ICommandAsync
	{
		public Frame Frame { get; protected set; }
		
		public SaveFrame(Frame frame)
		{
			this.Frame = frame;
		}
	}
}
