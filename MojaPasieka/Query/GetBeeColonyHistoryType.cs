using System;
using MojaPasieka.DataModel;
namespace MojaPasieka.cqrs
{
	public class GetBeeColonyHistoryType : IQuery<BeeColonyHistoryType>
	{
		public BeeColonyHistoryMain Type { get; protected set;}

		public GetBeeColonyHistoryType(BeeColonyHistoryMain type)
		{
			this.Type = type;
		}
	}
}
