using System;
using System.Threading.Tasks;

namespace MojaPasieka.View
{
	/// <summary>
	/// Interfejs do pokazywania okienek notyfikacji itp
	/// </summary>
	public interface INotification
	{
		Task<bool> askQuestion(string title, string question, string trueLabel, string falseLabel);

		void showAlert(string title, string message);

		void showToast(string message);
	}
}
