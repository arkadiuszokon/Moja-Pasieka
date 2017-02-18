using System;
using System.Threading.Tasks;
using MojaPasieka.DataModel;
using SQLite;

namespace MojaPasieka.cqrs
{
	public class GetParameterHandler : IQueryHandlerAsync<GetParameter, string>
	{

		private SQLiteAsyncConnection _database;

		public GetParameterHandler(SQLiteAsyncConnection database)
		{
			_database = database;
		}

		public async Task<string> ExecuteAsync(GetParameter query)
		{
			if (Parameter.cache.ContainsKey(query.pa_name))
			{
				return Parameter.cache[query.pa_name];
			}
			else
			{
				var res = await _database.QueryAsync<Parameter>("SELECT * FROM tb_prm_parameter WHERE pa_name = '" + query.pa_name + "'");
				if (res != null && res.Count != 0)
				{
					Parameter.cache[query.pa_name] = res[0].pa_value;
					return res[0].pa_value;
				}
				else
				{
					return "";
				}
			}
		}
	}
}
