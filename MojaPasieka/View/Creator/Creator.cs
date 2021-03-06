﻿using System;
using MojaPasieka.DataModel;
using Xamarin.Forms;
using Autofac;
using MojaPasieka.cqrs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MojaPasieka.View
{
	public class Creator : NavigationPage, IConsumerAsync<Event<Apiary>>, IConsumerAsync<Event<BeeHive>>, IConsumerAsync<Event<DataModel.Frame>>
	{

		protected static CarouselPage carousel;
		private List<BeeHive> addedBeeHives = new List<BeeHive>();
		private List<DataModel.Frame> addedFrames = new List<DataModel.Frame>();
		private List<Apiary> addedApiaries = new List<Apiary>();

		static Creator()
		{
			carousel = new CarouselPage();
			carousel.Title = "Kreator pasieki";
		}

		public Creator() : base(carousel)
		{
			Title = "Kreator pasieki";
			BarBackgroundColor = AppColors.MainColor;
			BarTextColor = AppColors.TextColor;
			carousel.Children.Add(new CreatorStart());
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				var eb = scope.Resolve<IEventPublisher>();
				eb.RegisterAsyncConsumer<Event<Apiary>>(this);
				eb.RegisterAsyncConsumer<Event<BeeHive>>(this);
				eb.RegisterAsyncConsumer<Event<DataModel.Frame>>(this);
			}
		}

		public Apiary apiary
		{
			get; private set;
		}

		public void setApiaryContext(Apiary apiary)
		{
			this.apiary = apiary;
		}


		public void replaceStep(ContentPage replaceWith)
		{
			carousel.Children.Remove(carousel.CurrentPage);
			carousel.Children.Add(replaceWith);
			carousel.CurrentPage = replaceWith;
		}

		public void nextStep()
		{
			if (carousel.CurrentPage is CreatorStart)
			{
				using (var scope = IoC.container.BeginLifetimeScope())
				{
					var qb = scope.Resolve<IQueryBus>();
					var apiaries = qb.Process<GetFullListOf, List<object>>(new GetFullListOf(typeof(Apiary)))
						.Cast<Apiary>().ToList();
					if (apiaries.Count > 0)
					{
						var selectApiary = new CreatorSelectApiary();
						carousel.Children.Add(selectApiary);
						carousel.CurrentPage = selectApiary;
					}
					else
					{
						var addApiary = new CreatorAddApiary();
						carousel.Children.Add(addApiary);
						carousel.CurrentPage = addApiary;
					}
				}
			}
			else if (carousel.CurrentPage is CreatorSelectApiary)
			{
				var makeBeeHives = new CreatorMakeBeeHives();
				carousel.Children.Add(makeBeeHives);
				carousel.CurrentPage = makeBeeHives;
			}
			else if (carousel.CurrentPage is CreatorAddApiary)
			{
				var makeBeeHives = new CreatorMakeBeeHives();
				carousel.Children.Add(makeBeeHives);
				carousel.CurrentPage = makeBeeHives;
			}
			else if (carousel.CurrentPage is CreatorMakeBeeHives)
			{
				var makeBeeColonies = new CreatorMakeBeeColonies();
				carousel.Children.Add(makeBeeColonies);
				carousel.CurrentPage = makeBeeColonies;
			}
			else if (carousel.CurrentPage is CreatorMakeBeeColonies)
			{
				close();
			}
			else
			{
				close("Wystąpił błąd w kretaorze");

			}
		}

		private void close(string error = "")
		{
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				if (error != String.Empty)
				{
					scope.Resolve<INotification>().showAlert("Błąd", error);
				}
				App.Current.MainPage = new AppMainPage();
			}
		}

		public int getCountBeeHivesAdded()
		{
			return addedBeeHives.Count;
		}

		public List<BeeHive> getBeeHivesAdded()
		{
			return this.addedBeeHives;
		}

		public async Task HandleAsync(Event<Apiary> eventMessage)
		{
			await Task.Run(() =>
			{
				if (eventMessage.Action == EventAction.CREATE)
				{
					setApiaryContext(eventMessage.Item);
					addedApiaries.Add(eventMessage.Item);
				}
			});
		}

		public async Task HandleAsync(Event<BeeHive> eventMessage)
		{
			await Task.Run(() => 
			{
				if (eventMessage.Action == EventAction.CREATE)
				{
					addedBeeHives.Add(eventMessage.Item);
				}
			});

		}

		public async Task HandleAsync(Event<DataModel.Frame> eventMessage)
		{
			await Task.Run(() =>
			{
				if (eventMessage.Action == EventAction.CREATE)
				{
					addedFrames.Add(eventMessage.Item);
				}
			});
		}
	}
}
