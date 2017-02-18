using System;
using System.Threading.Tasks;

namespace MojaPasieka.cqrs
{
	public interface IQueryHandlerAsync<in TQuery, TResult> where TQuery : IQuery<TResult>
	{
		/// <summary>
		/// Asynchroniczna obsługa zapytania
		/// </summary>
		/// <param name="query">The query to handle.</param>
		/// <returns>The query results.</returns>
		Task<TResult> ExecuteAsync(TQuery query);
	}
}
