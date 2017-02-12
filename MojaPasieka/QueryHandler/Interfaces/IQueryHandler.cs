using System;
namespace MojaPasieka.cqrs
{
	public interface IQueryHandler<in TQuery,  TResult> where TQuery : IQuery<TResult>
	{
		/// <summary>
		///    Wykonanie zapytania
		/// </summary>
		/// <param name="query">The query to handle.</param>
		/// <returns>The query results.</returns>
		TResult Execute(TQuery query);
	}
}
