using System;
using MojaPasieka.DataModel;
using SQLite.Net.Async;
using Xamarin.Forms;
using Autofac;

namespace MojaPasieka.Startup
{
	public class DBConnectTask : IStartupTask
	{
		private readonly ContainerBuilder _container;

		public DBConnectTask(ContainerBuilder container)
		{
			_container = container;
		}

		public void Execute()
		{
			var database = DependencyService.Get<IDatabaseConnection>().DBConnection();
			_container.RegisterInstance<SQLiteAsyncConnection>(database);
		}
	}
}
