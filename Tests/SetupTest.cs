using NUnit.Framework;
using System;
using MojaPasieka.Startup;
using System.Collections.Generic;

namespace Tests
{
	[SetUpFixture]
	public class SetupTest
	{
		[OneTimeSetUp]
		public void RunBeforeAnyTests()
		{
			AppStarter starter = new AppStarter(new List<IStartupTask>
			{
				new DatabaseConnectionForTests(),
				new RegisterTypesTask(),
			});
			starter.Start();
		}

		[OneTimeTearDown]
		public void RunAfterAnyTests()
		{
			// ...
		}
	}
}
