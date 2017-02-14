using MojaPasieka.cqrs;
using System.Reflection;
using System.Linq;
using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System;
using MojaPasieka.Startup;
using Autofac;

namespace MojaPasieka
{
	public partial class App : Application
	{
		public App()
		{
			
			InitializeComponent();

			var containerBuilder = new ContainerBuilder();


			var appStarter = new AppStarter(new List<IStartupTask> 
			{ 
				new DBConnectTask(containerBuilder), 
				new RegisterTypesTask(containerBuilder)
			});
			appStarter.Start();

			IoC.container = containerBuilder.Build();
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				scope.Resolve<ICommandBus>();
			}
				


			appStarter.Start();
			MainPage = new MojaPasiekaPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
