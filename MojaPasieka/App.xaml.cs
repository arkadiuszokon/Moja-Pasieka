using MojaPasieka.cqrs;
using System.Reflection;
using System.Linq;
using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System;
using MojaPasieka.Startup;
using Autofac;
using MojaPasieka.View;
using MojaPasieka.DataModel;
using System.Threading.Tasks;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

namespace MojaPasieka
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			try
			{
				starApp();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
			}
		}


		private async Task starApp()
		{
			

			var appStarter = new AppStarter(new List<IStartupTask>
			{
				new DBConnectTask(),
				new RegisterTypesTask(),
				new RegisterPlatformDependendTypesTask()
			});
			appStarter.Start();

			MainPage = new AppMainPage();

			using (var scope = IoC.container.BeginLifetimeScope())
			{
				try
				{
					
					var qb = scope.Resolve<IQueryBus>();
					var cb = scope.Resolve<ICommandBus>();
					/*
					var tutorialStatus = qb.Process<GetParameter, string>(new GetParameter(ParameterName.TUTORIAL_STATUS));
					if (tutorialStatus != "1")
					{
						await Task.Delay(500);
						var res = await scope.Resolve<INotification>().askQuestion("Witaj", "Czy chcesz uruchomić tutorial, aby zapoznać się z aplikacją?", "Tak", "Anuluj");
						if (res)
						{
							await cb.SendCommandAsync<ShowView>(new ShowView(new TutorialPage(), true));
							await cb.SendCommandAsync<SaveParameter>(new SaveParameter(ParameterName.TUTORIAL_STATUS, "1"));
						}
					}
					*/
					App.Current.MainPage = scope.Resolve<Creator>();
				}
				catch (Exception ex)
				{
					MobileCenterLog.Error(nameof(App), "", ex);
				}
			}

		}


		protected override void OnStart()
		{
			
			base.OnStart();
			MobileCenter.Start("android=e0b32b56-2713-4bdd-a130-82623fea2d59;" +
				   "ios={Your iOS App secret here}",
				   typeof(Analytics), typeof(Crashes));
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
