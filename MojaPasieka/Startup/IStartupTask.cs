using System;
using System.Threading.Tasks;
using Autofac;

namespace MojaPasieka.Startup
{
	public interface IStartupTask
	{
		void Execute(ContainerBuilder builder);
	}
}
