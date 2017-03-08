using System;
using MojaPasieka.DataModel;
namespace MojaPasieka.cqrs
{
	public class AddBeeHiveBody : ICommandAsync
	{
		public BeeHiveBody Body { get; protected set; }
		
		public AddBeeHiveBody(BeeHiveBody body)
		{
			this.Body = body;
		}
	}
}
