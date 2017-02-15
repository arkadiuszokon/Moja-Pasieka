using System;
using System.Collections.Generic;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class GetListOfBeeHives : IQuery<List<BeeHive>>
	{
		public GetListOfBeeHives()
		{
		}
	}
}
