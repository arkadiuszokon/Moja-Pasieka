using System;
using System.Threading.Tasks;
using Android.App;
using MojaPasieka.Droid;
using MojaPasieka.View;

[assembly: Xamarin.Forms.Dependency(typeof(Notification_Android))]
namespace MojaPasieka.Droid 
{
	public class Notification_Android : INotification
	{
		
		public Task<bool> askQuestion(string title, string question, string trueLabel, string falseLabel)
		{

			var tcs = new TaskCompletionSource<bool>();

			AlertDialog.Builder builder = new AlertDialog.Builder(Xamarin.Forms.Forms.Context);

			builder.SetMessage(question);
			builder.SetTitle(title);
			builder.SetPositiveButton(trueLabel, (object sender, Android.Content.DialogClickEventArgs e) => 
			{
				tcs.SetResult(true);
			});
			builder.SetNegativeButton(falseLabel, (object sender, Android.Content.DialogClickEventArgs e) => 
			{
				tcs.SetResult(false);
			});
			builder.Create().Show();

			return tcs.Task;
		}
	}
}
