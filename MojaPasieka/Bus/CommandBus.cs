using System;
using System.Threading.Tasks;
using MojaPasieka.IoC;

namespace MojaPasieka.cqrs
{
	/// <summary>
	/// Szyna komend
	/// </summary>
	public class CommandBus : ICommandBus
	{
		private readonly IResolver _resolver;
		private readonly IEventPublisher _eventPublisher;

		public CommandBus(IResolver resolver, IEventPublisher eventPublisher)
		{
			_resolver = resolver;
			_eventPublisher = eventPublisher;
		}

		/// <summary>
		/// Obsługa komendy
		/// </summary>
		/// <param name="cmd">Cmd.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public void SendCommand<TCommand>(TCommand cmd) where TCommand : ICommand
		{
			if (cmd == null)
			{
				throw new ArgumentNullException("command");
			}

			var commandHandler = _resolver.Resolve<ICommandHandler<TCommand>>();

			if (commandHandler == null)
			{
				throw new Exception(string.Format("No handler found for command '{0}'", cmd.GetType().FullName));
			}

			var events = commandHandler.Handle(cmd);

			foreach (var @event in events)
			{
				_eventPublisher.Publish(@event);
			}
		}

		/// <summary>
		/// Asynchroniczna obsługa komendy
		/// </summary>
		/// <returns>The command async.</returns>
		/// <param name="cmd">Cmd.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public async Task SendCommandAsync<TCommand>(TCommand cmd) where TCommand : ICommand
		{
			if (cmd == null)
			{
				throw new ArgumentNullException("command");
			}

			var commandHandler = _resolver.Resolve<ICommandHandlerAsync<TCommand>>();

			if (commandHandler == null)
			{
				throw new Exception(string.Format("No handler found for command '{0}'", cmd.GetType().FullName));
			}

			var events = await commandHandler.HandleAsync(cmd);

			foreach (var @event in events)
			{
				await _eventPublisher.PublishAsync(@event);
			}
			return;
		}
	}
}
