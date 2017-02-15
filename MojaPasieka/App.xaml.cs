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
			var containerBuilder = new ContainerBuilder();

			var appStarter = new AppStarter(new List<IStartupTask>
			{
				new DBConnectTask(containerBuilder),
				new RegisterTypesTask(containerBuilder),
			});
			appStarter.Start();
			try
			{
				IoC.container = containerBuilder.Build();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
			}

			using (var scope = IoC.container.BeginLifetimeScope())
			{
				var models = scope.Resolve<IEnumerable<DataModel.IDataModel>>();
				var database = scope.Resolve<SQLite.SQLiteAsyncConnection>();
				var method = database.GetType().GetRuntimeMethods().Where((MethodInfo arg) => arg.Name == "CreateTableAsync").First();
				foreach (var model in models)
				{
					var res = await (dynamic)method.MakeGenericMethod(new Type[] { model.getDataModelType() }).Invoke(database, new object[] { SQLite.CreateFlags.None });
				}

				var cb = scope.Resolve<ICommandBus>();
				await cb.SendCommandAsync<AddBeeHiveCommand>(new AddBeeHiveCommand(new DataModel.BeeHive() { ul_name="Test1" }));
			}



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
