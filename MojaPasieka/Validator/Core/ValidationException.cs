using System;
using Autofac;
using MojaPasieka.View;
using Xamarin.Forms;

namespace MojaPasieka.cqrs
{
	public class ValidationException : Exception
	{
		public ValidationResult Result { get; protected set; }

		public ValidationException(ValidationResult result)
		{
			this.Result = result;
		}

		public void MenageError()
		{
			
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				if (Result.Messages.Count > 0)
				{
					scope.Resolve<INotification>().showAlert("Błąd", String.Join("\n", Result.Messages));
				}
				else
				{
					scope.Resolve<INotification>().showAlert("Błąd", "Wystąpił nieznany błąd walidacji");
				}
			}
		}
	}
}
