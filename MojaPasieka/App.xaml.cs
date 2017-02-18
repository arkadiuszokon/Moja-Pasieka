using MojaPasieka.cqrs;
using System.Reflection;
using System.Linq;
using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System;
using System.Reflection;
using MojaPasieka.Startup;
using Autofac;
using MojaPasieka.DataModel;

namespace MojaPasieka
{
	public partial class App : Application
	{
		public App()
		{
			
			InitializeComponent();
			starApp();

		}


		private async void starApp()
		{
			

			var appStarter = new AppStarter(new List<IStartupTask>
			{
				new DBConnectTask(),
				new RegisterTypesTask(),
			});
			appStarter.Start();

			MainPage = new AppMainPage();

			using (var scope = IoC.container.BeginLifetimeScope())
			{
				var qb = scope.Resolve<IQueryBus>();
				var cb = scope.Resolve<ICommandBus>();
				var tutorialStatus = await qb.ProcessAsync<GetParameter, string>(new GetParameter(ParameterName.TUTORIAL_STATUS));
				if (tutorialStatus != "1")
				{
					var res = await MainPage.DisplayAlert("Witaj", "Czy chcesz uruchomić tutorial, aby zapoznać się z aplikacją?", "Tak", "Anuluj");
					if (res)
					{
						await cb.SendCommandAsync<ShowView>(new ShowView(new TutorialPage(), true));
						await cb.SendCommandAsync<SaveParameter>(new SaveParameter(ParameterName.TUTORIAL_STATUS, "1"));
					}
				}
			}
		}


		protected override void OnStart()
		{
			// Handle when your app starts
			base.OnStart();
		}

		protected override void OnSleep()
		{
			base.OnSleep();
		}

		protected override void OnResume()
		{
			base.OnResume();
		}
	}
}
