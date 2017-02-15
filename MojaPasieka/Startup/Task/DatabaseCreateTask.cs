using System;
using System.Threading.Tasks;
using SQLite;
using Autofac;
using System.Collections.Generic;
using System.Reflection;
using MojaPasieka.DataModel;

namespace MojaPasieka.Startup
{
	public class DatabaseCreateTask : IStartupTask
	{
		public DatabaseCreateTask()
		{
			
		}

		public async Task<bool> Execute()
		{
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				var database = scope.Resolve<SQLiteAsyncConnection>();
				var dataModels = scope.Resolve<IEnumerable<DataModelBase>>();
				foreach (var dm in dataModels)
				{
					var method = database.GetType().GetRuntimeMethod("CreateTableAsync", new Type[] { }).MakeGenericMethod(new Type[] { dm.GetType() });
					method.Invoke(database, new object[] { });
				}
			}
			return true;
		}
	}
}
