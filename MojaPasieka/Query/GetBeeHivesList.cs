using System;
using System.Collections.Generic;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class GetBeeHivesList : IQuery<List<BeeHivesListItem>>
	{
		public int ApiaryId { get; protected set; }

		public GetBeeHivesList(int apiaryId)
		{
			this.ApiaryId = apiaryId;
		}
	}
}
