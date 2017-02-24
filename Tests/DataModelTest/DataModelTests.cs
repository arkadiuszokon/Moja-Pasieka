using System;
using SQLite;
using NUnit.Framework;
using Autofac;
using MojaPasieka.DataModel;
using MojaPasieka.cqrs;
using MojaPasieka;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Tests
{
	[TestFixture]
	public class DataModelTests : IConsumerAsync<Event<Apiary>>, IConsumerAsync<Event<BeeBreed>>
	{
		private IQueryBus qb;
		private ICommandBus cb;
		private IEventPublisher eb;

		[SetUp]
		public void setupDataModelTests()
		{
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				qb = scope.Resolve<IQueryBus>();
				cb = scope.Resolve<ICommandBus>();
				eb = scope.Resolve<IEventPublisher>();
			}
		}

		[Test]
		public async Task checkApiary()
		{
			eb.RegisterAsyncConsumer<Event<Apiary>>(this);
			var tmpQuan = qb.Process<GetNumOfRowsInTable, int>(new GetNumOfRowsInTable(typeof(Apiary)));
			var apiary = new Apiary
			{
				ap_datecreated = DateTime.Now,
				ap_desc = "Opis pasieki",
				ap_latlng = "51,323;21,894",
				ap_name = "Przykładowa pasieka",
				ap_timestamp = DateTime.Now
			};
			await cb.SendCommandAsync<AddApiary>(new AddApiary(apiary));

			var currentQuan = qb.Process<GetNumOfRowsInTable, int>(new GetNumOfRowsInTable(typeof(Apiary)));
			Assert.True(currentQuan == tmpQuan + 1, "Dodanie elementu");
			Assert.True(apiary.ap_id != 0, "Ustawił się ID z autoincrementa");

			var apiaries = qb.Process<GetFullListOf, List<object>>(new GetFullListOf(typeof(Apiary))).Cast<Apiary>().ToList();
			Assert.True(apiaries.Count > 0, "Pobrano listę");
			Assert.True(apiaries.Exists((Apiary obj) => { return obj.ap_id == apiary.ap_id; }), "Nie ma elementu na liście");

			await cb.SendCommandAsync<DeleteApiary>(new DeleteApiary(apiary));

			currentQuan = qb.Process<GetNumOfRowsInTable, int>(new GetNumOfRowsInTable(typeof(Apiary)));
			Assert.True(currentQuan == tmpQuan, "usunięto element");
		}

		[Test]
		public async Task checkBeeBreed()
		{
			eb.RegisterAsyncConsumer<Event<BeeBreed>>(this);
			var tmpQuan = qb.Process<GetNumOfRowsInTable, int>(new GetNumOfRowsInTable(typeof(BeeBreed)));
			var beeBreed = new BeeBreed
			{
				bb_desc="",
				bb_name="TEST",
				bb_timestamp=DateTime.Now
			};
			await cb.SendCommandAsync<AddBeeBreed>(new AddBeeBreed(beeBreed));

			var currentQuan = qb.Process<GetNumOfRowsInTable, int>(new GetNumOfRowsInTable(typeof(BeeBreed)));
			Assert.True(currentQuan == tmpQuan + 1, "Dodanie elementu");
			Assert.True(beeBreed.bb_id != 0, "Ustawił się ID z autoincrementa");

			var apiaries = qb.Process<GetFullListOf, List<object>>(new GetFullListOf(typeof(BeeBreed))).Cast<BeeBreed>().ToList();
			Assert.True(apiaries.Count > 0, "Pobrano listę");
			Assert.True(apiaries.Exists((BeeBreed obj) => { return obj.bb_id == beeBreed.bb_id; }), "Nie ma elementu na liście");

			await cb.SendCommandAsync<DeleteBeeBreed>(new DeleteBeeBreed(beeBreed));

			currentQuan = qb.Process<GetNumOfRowsInTable, int>(new GetNumOfRowsInTable(typeof(BeeBreed)));
			Assert.True(currentQuan == tmpQuan, "usunięto element");
		}

		[Explicit]
		public async Task HandleAsync(Event<Apiary> eventMessage)
		{
			await Task.Delay(10);
			Assert.IsInstanceOf(typeof(Apiary),eventMessage.item,"błędny typ danych w evencie");
		}

		[Explicit]
		public async Task HandleAsync(Event<BeeBreed> eventMessage)
		{
			await Task.Delay(10);
			Assert.IsInstanceOf(typeof(BeeBreed), eventMessage.item, "błędny typ danych w evencie");
		}
	}
}
