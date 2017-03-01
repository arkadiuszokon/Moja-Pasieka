using System;
using System.Collections.Generic;
using System.Reflection;
using MojaPasieka.cqrs;
using Autofac;
using MojaPasieka.View;
using MojaPasieka.DataModel;
using System.Threading.Tasks;
using MojaPasieka.Utils;

namespace MojaPasieka.Startup
{
	public class RegisterTypesTask : IStartupTask
	{


		public RegisterTypesTask()
		{
		}

		public void Execute(ContainerBuilder builder)
		{
			//rejestrujemy kontener
			//_container.Register<IResolver>(_container.GetResolver());


			//rejestrujemy elementy cqrsa
			builder.RegisterType<EventBus>().As<IEventPublisher>().SingleInstance();
			builder.RegisterType<CommandBus>().As<ICommandBus>().SingleInstance();
			builder.RegisterType<QueryBus>().As<IQueryBus>().SingleInstance();
			builder.RegisterType<Creator>().As<Creator>().SingleInstance();
			builder.RegisterType<MapUtil>().As<IMap>().SingleInstance();


			var currentdomain = typeof(string).GetTypeInfo().Assembly.GetType("System.AppDomain").GetRuntimeProperty("CurrentDomain").GetMethod.Invoke(null, new object[] { });
			var getassemblies = currentdomain.GetType().GetRuntimeMethod("GetAssemblies", new System.Type[] { });
			var assemblies = getassemblies.Invoke(currentdomain, new object[] { }) as Assembly[];
			for (var i = 0; i < assemblies.Length; i++)
			{
				if (assemblies[i].GetName().Name == "MojaPasieka")
				{

					builder.RegisterAssemblyTypes(assemblies[i]).AsClosedTypesOf(typeof(ICommandHandler<>)).SingleInstance();
					builder.RegisterAssemblyTypes(assemblies[i]).AsClosedTypesOf(typeof(ICommandHandlerAsync<>)).SingleInstance();
					builder.RegisterAssemblyTypes(assemblies[i]).AsClosedTypesOf(typeof(IValidator<>)).SingleInstance();
					builder.RegisterAssemblyTypes(assemblies[i]).AsClosedTypesOf(typeof(IValidatorAsync<>)).SingleInstance();
					builder.RegisterAssemblyTypes(assemblies[i]).AsClosedTypesOf(typeof(IQueryHandler<,>)).SingleInstance();
					builder.RegisterAssemblyTypes(assemblies[i]).AssignableTo<DataModelBase>().AsImplementedInterfaces().SingleInstance();
					builder.RegisterAssemblyTypes(assemblies[i]).AssignableTo<IViewModel>().WithParameter(new TypedParameter(typeof(ViewPage<>), "view"));


					//IEnumerable<TypeInfo> types = assemblies[i].DefinedTypes;

				}
			}
			

		}
	}
}
