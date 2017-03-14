using System;
using MojaPasieka.DataModel;
using Autofac;
using System.Threading.Tasks;

namespace MojaPasieka.cqrs
{
	public class GetApiaryContextHandler : QueryHandlerBase, IQueryHandler<GetApiaryContext, Apiary>, IConsumerAsync<ParameterWasChanged>
	{
		private static Apiary currentApiary;

		public Apiary Execute(GetApiaryContext query)
		{
			if (currentApiary != null)
			{
				return currentApiary;
			}
			else
			{
				using (var scope = IoC.container.BeginLifetimeScope())
				{
					scope.Resolve<IEventPublisher>().RegisterAsyncConsumer<ParameterWasChanged>(this);
					var qb = scope.Resolve<IQueryBus>();
					var currentApiaryID = qb.Process<GetParameter, string>(new GetParameter(ParameterName.CURRENT_APIARY_ID));
					if (currentApiaryID == String.Empty)
					{
						throw (new Exception("Ta operacja wymaga wybrania pasieki, przejdź do listy pasiek i stwórz/wybierz jakąś"));
					}
					else
					{
						var res = Connection.FindWithQuery<Apiary>("SELECT * FROM tb_apiary WHERE ap_id = " + currentApiaryID);
						currentApiary = res;
						return currentApiary;
					}
				}
			}
		}

		public async Task HandleAsync(ParameterWasChanged eventMessage)
		{
			if (eventMessage.pa_name == ParameterName.CURRENT_APIARY_ID)
			{
				await Task.Run(() =>
				{
					currentApiary = Connection.FindWithQuery<Apiary>("SELECT * FROM tb_apiary WHERE ap_id = " + eventMessage.pa_value);
				});
			}
		}
	}
}
