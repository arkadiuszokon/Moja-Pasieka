using System;
using MojaPasieka.DataModel;
using Autofac;
using System.Collections.Generic;

namespace MojaPasieka.cqrs
{
	public class GetFrameTypesByMainType : IQuery<List<FrameType>>
	{
		public FrameTypeMain typeMain { get; protected set; }

		public GetFrameTypesByMainType(FrameTypeMain typeMain)
		{
			this.typeMain = typeMain;
		}
	}
}
