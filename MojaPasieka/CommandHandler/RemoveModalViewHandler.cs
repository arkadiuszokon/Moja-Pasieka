using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MojaPasieka.cqrs
{
	public class RemoveModalViewHandler : ICommandHandlerAsync<RemoveModalView>
	{
		public RemoveModalViewHandler()
		{
		}

		public async Task HandleAsync(RemoveModalView command)
		{
			await Application.Current.MainPage.Navigation.PopModalAsync(true);
		}
	}
}
