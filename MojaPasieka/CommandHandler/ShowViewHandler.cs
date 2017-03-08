using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using MojaPasieka.View;
namespace MojaPasieka.cqrs
{
	public class ShowViewHandler : ICommandHandlerAsync<ShowView>
	{

		public async Task HandleAsync(ShowView command)
		{
			if (command.AsRoot)
			{
				AppMainPage.setRootPage(command.View);

			}
			else
			{
				await AppMainPage.nav.PushAsync(command.View);

			}
		}

	}
}
