using System;
using Autofac;
using MojaPasieka;
using MojaPasieka.cqrs;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class BusTests
	{
		[Test]
		public void checkCommandBus()
		{
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				var cb = scope.Resolve<ICommandBus>();

				Assert.True(cb is ICommandBus);
				Assert.Throws<Exception>(() => { cb.SendCommand(new CommandTest()); });
			}
		}

		[Test]
		public void checkQueryBus()
		{
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				var cb = scope.Resolve<IQueryBus>();

				Assert.True(cb is IQueryBus);
				Assert.Throws<Exception>(() => { cb.Process<QueryTest, int>(new QueryTest()); });
			}
		}

		[Test]
		public void checkEventBus()
		{
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				var cb = scope.Resolve<IEventPublisher>();

				Assert.True(cb is IEventPublisher);

			}
		}
	}

	public class QueryTest : IQuery<int>
	{

	}

	public class CommandTest : ICommand
	{

	}
}
