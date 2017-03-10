using System;
using System.Diagnostics;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class CheckExistsHandler : QueryHandlerBase, IQueryHandler<CheckExists, bool>
	{
		
		public bool Execute(CheckExists query)
		{
			var map = Connection.GetMapping(query.DataModelType);
			var rowCount = Connection.ExecuteScalar<int>("SELECT COUNT(*) FROM " + DataModelBase.GetTableName(query.DataModelType) + " WHERE " + map.PK.Name + " = " + query.PrimaryKey.ToString());
			return rowCount > 0;
		}
	}
}
