using System;
using System.Threading.Tasks;

namespace MojaPasieka.cqrs
{
	/// <summary>
	/// Interfejs dla szyny komend
	/// </summary>
	public interface ICommandBus
	{
		/// <summary>
		/// Obsługa komendy
		/// </summary>
		/// <param name="cmd">Cmd.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		void SendCommand<TCommand>(TCommand cmd) where TCommand : ICommand;

		/// <summary>
		/// Asynchroniczna obsługa komendy
		/// </summary>
		/// <returns>The command async.</returns>
		/// <param name="cmd">Cmd.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		Task SendCommandAsync<TCommand>(TCommand cmd) where TCommand : ICommand;
	}
}
