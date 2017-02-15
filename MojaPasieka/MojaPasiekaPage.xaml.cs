using System;
using System.Threading.Tasks;
using MojaPasieka.cqrs;
using Xamarin.Forms;
using Autofac;
using System.Diagnostics;

namespace MojaPasieka
{
	public partial class MojaPasiekaPage : ContentPage, IConsumerAsync<BeeHiveAddedEvent>
	{
		public MojaPasiekaPage()
		{
			InitializeComponent();
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				var ep = scope.Resolve<IEventPublisher>();
				ep.RegisterAsyncConsumer<BeeHiveAddedEvent>(this);
			}
		}

		public async Task HandleAsync(BeeHiveAddedEvent eventMessage)
		{
			
			Debug.WriteLine("uff");
			await Task.Delay(100);

		}


	}
}
