using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MojaPasieka.cqrs
{
	public class ShowModalViewHandler : ICommandHandlerAsync<ShowModalView>
	{
		public ShowModalViewHandler()
		{
		}

		public async Task HandleAsync(ShowModalView command)
		{
			await Application.Current.MainPage.Navigation.PushModalAsync(command.View);
		}
	}
}
