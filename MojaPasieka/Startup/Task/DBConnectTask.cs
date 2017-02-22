using System;
using MojaPasieka.DataModel;
using SQLite;
using Xamarin.Forms;
using Autofac;
using System.Threading.Tasks;

namespace MojaPasieka.Startup
{
	public class DBConnectTask : IStartupTask
	{

		public DBConnectTask()
		{
		}

		public void Execute(ContainerBuilder builder)
		{
			var database = DependencyService.Get<IDatabaseConnection>().DBConnection();
			builder.RegisterInstance<SQLiteConnection>(database);

		}
	}
}
