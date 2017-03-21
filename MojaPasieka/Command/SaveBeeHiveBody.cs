using System;
using MojaPasieka.DataModel;
namespace MojaPasieka.cqrs
{
	public class SaveBeeHiveBody : ICommandAsync
	{
		public BeeHiveBody Body { get; protected set; }
		
		public SaveBeeHiveBody(BeeHiveBody body)
		{
			this.Body = body;
		}
	}
}
