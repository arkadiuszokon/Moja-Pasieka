using System;
using System.Collections.Generic;
using MojaPasieka.DataModel;
using SQLite;

namespace MojaPasieka.cqrs
{
	public class GetFrameTypesByMainTypeHandler : QueryHandlerBase, IQueryHandler<GetFrameTypesByMainType, List<FrameType>>
	{
		public List<FrameType> Execute(GetFrameTypesByMainType query)
		{
			return Connection.Query<FrameType>("SELECT * FROM " + DataModelBase.GetTableName(typeof(FrameType)) + " WHERE ft_type = " + ((int)query.typeMain).ToString());
		}
	}
}
