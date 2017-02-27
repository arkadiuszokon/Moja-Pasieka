using System;
using Autofac;
using MojaPasieka.View;
using Xamarin.Forms;

namespace MojaPasieka.Startup
{
	public class RegisterPlatformDependendTypesTask : IStartupTask
	{
		public RegisterPlatformDependendTypesTask()
		{
		}

		public void Execute(ContainerBuilder builder)
		{
			builder.RegisterInstance<INotification>(DependencyService.Get<INotification>());
		}
	}
}
