using System;
using System.Threading.Tasks;
using Autofac;

namespace MojaPasieka.cqrs
{
	public class QueryBus:IQueryBus
	{

		private readonly ILifetimeScope _resolver;


		public QueryBus(ILifetimeScope resolver)
		{
			_resolver = resolver;
		}

		/// <summary>
		/// Wykonanie zapytania
		/// </summary>
		/// <param name="query">Query.</param>
		/// <typeparam name="TQuery">The 1st type parameter.</typeparam>
		/// <typeparam name="TResult">The 2nd type parameter.</typeparam>
		public TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
		{
			if (query == null)
			{
				throw new ArgumentNullException("query");
			}

			var queryHandler = _resolver.ResolveOptional<IQueryHandler<TQuery,TResult>>();

			if (queryHandler == null)
			{
				throw new Exception(string.Format("No handler found for qyery '{0}'", query.GetType().FullName));
			}

			return queryHandler.Execute(query);
		}

		/// <summary>
		/// Asynchroniczne wykonanie zapytania
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="query">Query.</param>
		/// <typeparam name="TQuery">The 1st type parameter.</typeparam>
		/// <typeparam name="TResult">The 2nd type parameter.</typeparam>
		public async Task<TResult> ProcessAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
		{
			if (query == null)
			{
				throw new ArgumentNullException("query");
			}

			var queryHandler = _resolver.ResolveOptional<IQueryHandlerAsync<TQuery, TResult>>();

			if (queryHandler == null)
			{
				throw new Exception(string.Format("No handler found for qyery '{0}'", query.GetType().FullName));
			}

			return await queryHandler.ExecuteAsync(query);
		}
	}
}
