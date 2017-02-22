using System;
using System.Threading.Tasks;
using MojaPasieka.DataModel;
using SQLite;

namespace MojaPasieka.cqrs
{
	public class GetParameterHandler : IQueryHandler<GetParameter, string>
	{

		private SQLiteConnection _database;

		public GetParameterHandler(SQLiteConnection database)
		{
			_database = database;
		}

		public string Execute(GetParameter query)
		{
			if (Parameter.cache.ContainsKey(query.pa_name))
			{
				return Parameter.cache[query.pa_name];
			}
			else
			{
				
				var res = _database.ExecuteScalar<string>("SELECT pa_value FROM tb_parameter WHERE pa_name = '" + query.pa_name + "'");
				if (res != null)
				{
					Parameter.cache[query.pa_name] = res;
					return res;
				}
				else
				{
					return "";
				}
			}
		}
	}
}
