using System;
using System.Collections.Generic;
using MojaPasieka.DataModel;
namespace MojaPasieka.cqrs
{
	public class GetFullListOf : IQuery<List<object>> 
	{

		public Type dataModel { get; private set; }

		public GetFullListOf(Type dataModel)
		{
			this.dataModel = dataModel;
		}
	}
}
