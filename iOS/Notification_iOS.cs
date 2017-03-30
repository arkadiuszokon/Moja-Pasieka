using System;
using System.Threading.Tasks;
using MojaPasieka.iOS;
using MojaPasieka.View;
[assembly: Xamarin.Forms.Dependency (typeof (Notification_iOS))]
namespace MojaPasieka.iOS
{
	public class Notification_iOS :INotification
	{
		public Notification_iOS ()
		{
		}

		public async Task<bool> askQuestion (string title, string question, string trueLabel, string falseLabel)
		{
			return true;
		}

		public void showAlert (string title, string message)
		{
			
		}

		public void showToast (string message)
		{
			
		}

	}
}
