using System;
using System.Collections.Generic;

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

			foreach (var task in _tasks)
			{

				task.Execute();

			}

		}	
	}
}
