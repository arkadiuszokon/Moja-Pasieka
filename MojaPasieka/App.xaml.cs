using MojaPasieka.cqrs;
using System.Reflection;

using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System;

namespace MojaPasieka
{
	public partial class App : Application
	{
		public App()
		{
			var currentdomain = typeof(string).GetTypeInfo().Assembly.GetType("System.AppDomain").GetRuntimeProperty("CurrentDomain").GetMethod.Invoke(null, new object[] { });
			var getassemblies = currentdomain.GetType().GetRuntimeMethod("GetAssemblies", new System.Type[] { });
			var assemblies = getassemblies.Invoke(currentdomain, new object[] { }) as Assembly[];
			for (var i = 0; i < assemblies.Length; i++)
			{
				if (assemblies[i].GetName().Name == "MojaPasieka")
				{
					IEnumerable<TypeInfo> types = assemblies[i].DefinedTypes;
					foreach (var type in types)
					{
						
					}
				}
			}
			InitializeComponent();
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
