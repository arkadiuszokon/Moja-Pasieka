using System;
using Autofac;
using System.Diagnostics;
using MojaPasieka.View;
using Xamarin.Forms;

namespace MojaPasieka
{
	public static class ErrorUtil
	{
		public static void handleError(Exception ex)
		{
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				scope.Resolve<INotification>().showAlert("Błąd", ex.Message);
			}
			Debug.WriteLine(ex.Message);
		}
	}
}
