using System;
using System.Threading.Tasks;
using MojaPasieka.View;
using Xamarin.Forms;

namespace MojaPasieka.cqrs
{
	public class RemoveViewHandler : ICommandHandlerAsync<RemoveView>
	{
		public async Task HandleAsync(RemoveView command)
		{
			Device.BeginInvokeOnMainThread(async () =>
			{
				await AppMainPage.nav.PopAsync();
			});
		}
	}
}
