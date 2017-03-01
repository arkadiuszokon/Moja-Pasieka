using System;
using System.Threading.Tasks;
using Android.App;
using Android.Widget;
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

		public void showAlert(string title, string message)
		{
			AlertDialog.Builder builder = new AlertDialog.Builder(Xamarin.Forms.Forms.Context);

			builder.SetMessage(message);
			builder.SetTitle(title);
			builder.SetPositiveButton("OK", (object sender, Android.Content.DialogClickEventArgs e) =>
			{
				
			});
			builder.Create().Show();
		}

		public void showToast(string message)
		{
			Toast.MakeText(Xamarin.Forms.Forms.Context, message, ToastLength.Short).Show();
		}
	}
}
