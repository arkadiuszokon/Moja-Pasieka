﻿using System;
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

		public string tmp = "";

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

			var commandHandler = _resolver.Resolve<ICommandHandler<TCommand>>();

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
		public async Task SendCommandAsync<TCommand>(TCommand cmd) where TCommand : ICommand
		{
			if (cmd == null)
			{
				throw new ArgumentNullException("command");
			}
			try
			{
				var commandHandler = _resolver.Resolve<ICommandHandlerAsync<TCommand>>();
				if (commandHandler == null)
				{
					throw new Exception(string.Format("No handler found for command '{0}'", cmd.GetType().FullName));
				}


				await commandHandler.HandleAsync(cmd);


			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
			}


			return;
		}
	}
}
