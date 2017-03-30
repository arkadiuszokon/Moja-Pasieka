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

using Xamarin.Forms.Xaml;

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
				}
				catch (Exception ex)
				{
					Debug.WriteLine (ex.ToString ());
				}
			}

		}


		protected override void OnStart()
		{
			
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
