﻿using System;
using System.Collections.Generic;
using System.Reflection;
using MojaPasieka.cqrs;
using Autofac;

namespace MojaPasieka.Startup
{
	public class RegisterTypesTask : IStartupTask
	{

		private readonly ContainerBuilder _container;

		public RegisterTypesTask(ContainerBuilder container)
		{
			_container = container;
		}

		public void Execute()
		{
			//rejestrujemy kontener
			//_container.Register<IResolver>(_container.GetResolver());

			//rejestrujemy elementy cqrsa
			_container.RegisterType<EventBus>().As<IEventPublisher>().SingleInstance();
			_container.RegisterType<CommandBus>().As<ICommandBus>().SingleInstance();
			_container.RegisterType<QueryBus>().As<IQueryBus>().SingleInstance();



			var currentdomain = typeof(string).GetTypeInfo().Assembly.GetType("System.AppDomain").GetRuntimeProperty("CurrentDomain").GetMethod.Invoke(null, new object[] { });
			var getassemblies = currentdomain.GetType().GetRuntimeMethod("GetAssemblies", new System.Type[] { });
			var assemblies = getassemblies.Invoke(currentdomain, new object[] { }) as Assembly[];
			for (var i = 0; i < assemblies.Length; i++)
			{
				if (assemblies[i].GetName().Name.Contains("MojaPasieka"))
				{
					IEnumerable<TypeInfo> types = assemblies[i].DefinedTypes;
					foreach (var type in types)
					{
					}
				}
			}
		}
	}
}