using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Autofac;

namespace MojaPasieka.cqrs
{
	/// <summary>
	/// Szyna komend
	/// </summary>
	public class CommandBus : ICommandBus
	{

		private readonly ILifetimeScope _resolver;
		private readonly IEventPublisher _eventPublisher;

		public CommandBus(ILifetimeScope resolver, IEventPublisher eventPublisher)
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

			var commandValidator = _resolver.ResolveOptional<IValidator<TCommand>>();
			if (commandValidator != null)
			{
				var res = commandValidator.Validate(cmd);
				if (res.result == false)
				{
					throw new ValidationException(res);
				}
			}

			var commandHandler = _resolver.ResolveOptional<ICommandHandler<TCommand>>();
			if (commandHandler == null)
			{
				throw new Exception(string.Format("No handler found for command '{0}'", cmd.GetType().FullName));
			}

			commandHandler.Handle(cmd);


		}

		/// <summary>
		/// Asynchroniczna obsługa komendy
		/// </summary>
		/// <returns>The command async.</returns>
		/// <param name="cmd">Cmd.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public async Task SendCommandAsync<TCommand>(TCommand cmd) where TCommand : ICommandAsync
		{

			var commandValidatorAsync = _resolver.ResolveOptional<IValidatorAsync<TCommand>>();
			if (commandValidatorAsync != null)
			{
				var res = await commandValidatorAsync.Validate(cmd);
				if (res.result == false)
				{
					throw new ValidationException(res);
				}
			}

			var commandValidator = _resolver.ResolveOptional<IValidator<TCommand>>();
			if (commandValidator != null)
			{
				var res = commandValidator.Validate(cmd);
				if (res.result == false)
				{
					throw new ValidationException(res);
				}
			}

			var commandHandler = _resolver.ResolveOptional<ICommandHandlerAsync<TCommand>>();
			if (commandHandler == null)
			{
				throw new Exception(string.Format("No handler found for command '{0}'", cmd.GetType().FullName));
			}


			await commandHandler.HandleAsync(cmd);

		}
	}
}
