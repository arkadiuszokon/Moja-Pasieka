using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using MojaPasieka.cqrs;
using MojaPasieka.DataModel;
using SQLite;

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

		public void Start()
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
				try
				{
					var models = scope.Resolve<IEnumerable<DataModel.IDataModel>>();
					var database = scope.Resolve<SQLite.SQLiteConnection>();

					//var method = database.GetType().GetRuntimeMethods().Where((MethodInfo arg) => arg.Name == "CreateTable").First();
					//database.CreateTable<BeeHive>();

					foreach (var model in models)
					{

						//var generic = method.MakeGenericMethod(new Type[] { model.getDataModelType() });
						//var res = generic.Invoke(database, new object[] { SQLite.CreateFlags.None });
						var res = database.CreateTable(model.getDataModelType());

						if (model is IDataModelSelfInit)
						{	
							(model as IDataModelSelfInit).fillWithData(database);
						}
					}

				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.ToString());
				}


			}
		}	
	}
}
