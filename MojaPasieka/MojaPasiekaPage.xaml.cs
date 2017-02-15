using System;
using System.Threading.Tasks;
using MojaPasieka.cqrs;
using Xamarin.Forms;
using Autofac;
using System.Diagnostics;
using System.Collections.Generic;
using MojaPasieka.DataModel;

namespace MojaPasieka
{
	public partial class MojaPasiekaPage : ContentPage, IConsumerAsync<BeeHiveWasAdded>
	{
		public MojaPasiekaPage()
		{
			InitializeComponent();
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				var ep = scope.Resolve<IEventPublisher>();
				ep.RegisterAsyncConsumer<BeeHiveWasAdded>(this);
			}
		}

		public async Task HandleAsync(BeeHiveWasAdded eventMessage)
		{
			
			Debug.WriteLine("uff");
			await Task.Delay(100);

			using (var scope = IoC.container.BeginLifetimeScope())
			{
				var qb = scope.Resolve<IQueryBus>();
				var beeHives = await qb.ProcessAsync<GetListOfBeeHives, List<BeeHive>>(new GetListOfBeeHives());
				Debug.WriteLine(beeHives.Count);
			}

		}


	}
}
