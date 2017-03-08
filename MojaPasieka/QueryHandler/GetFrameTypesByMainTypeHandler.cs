using System;
using System.Collections.Generic;
using MojaPasieka.DataModel;
using SQLite;

namespace MojaPasieka.cqrs
{
	public class GetFrameTypesByMainTypeHandler : IQueryHandler<GetFrameTypesByMainType, List<FrameType>>
	{
		protected SQLiteConnection _database;

		public GetFrameTypesByMainTypeHandler(SQLiteConnection database)
		{
			_database = database;
		}

		public List<FrameType> Execute(GetFrameTypesByMainType query)
		{
			return _database.Query<FrameType>("SELECT * FROM " + DataModelBase.GetTableName(typeof(FrameType)) + " WHERE ft_type = " + ((int)query.typeMain).ToString());
		}
	}
}
