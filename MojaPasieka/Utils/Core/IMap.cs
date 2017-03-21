using System;
using System.Threading.Tasks;

namespace MojaPasieka.Utils
{
	public interface IMap
	{
		void showMap();

		Task showMapForLocation(Action<string> onUserSelectPoint, double currentLat = 0, double currentLng = 0);

	}
}
