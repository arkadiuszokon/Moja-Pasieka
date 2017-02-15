using System;
using System.Threading.Tasks;

namespace MojaPasieka.Startup
{
	public interface IStartupTask
	{
		void Execute();
	}
}
