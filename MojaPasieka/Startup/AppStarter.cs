using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using MojaPasieka.cqrs;
using MojaPasieka.DataModel;

namespace MojaPasieka.Startup
{
	public interface IAppStarter
	{
		void Start();
	}

	public class AppStarter : IAppStarter
	{
		private readonly IEnumerable<IStartupTask> _tasks;

		public AppStarter(IEnumerable<IStartupTask> tasks)
		{
			_tasks = tasks;
		}

		public async void Start()
		{
			ContainerBuilder builder = new ContainerBuilder();
			foreach (var task in _tasks)
			{
				 task.Execute(builder); //wykonujemy taski
			}
			try
			{
				IoC.container = builder.Build();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
			}

			//tworzymy model bazy danych
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				var models = scope.Resolve<IEnumerable<DataModel.IDataModel>>();
				var database = scope.Resolve<SQLite.SQLiteAsyncConnection>();
				var method = database.GetType().GetRuntimeMethods().Where((MethodInfo arg) => arg.Name == "CreateTableAsync").First();
				foreach (var model in models)
				{
					var res = await(dynamic)method.MakeGenericMethod(new Type[] { model.getDataModelType() }).Invoke(database, new object[] { SQLite.CreateFlags.None });
				}


			}
		}	
	}
}
