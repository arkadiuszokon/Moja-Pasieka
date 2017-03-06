using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using MojaPasieka.DataModel;
using Autofac;
using MojaPasieka.cqrs;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MojaPasieka.View
{
	public class CreatorSelectApiaryModel : ViewModelBase, IViewModel
	{

		private ObservableCollection<Apiary> _apiaryList;
		private Apiary _selectedItem;
		public Command NextStep { get; protected set; }
		public Command AddApiary { get; protected set; }
		private bool _isNextStepVisible = false;
		private bool _isListEnabled = true;
		private bool _isAddApiaryVisible = true;

		public bool IsNextStepVisible
		{
			get
			{
				return _isNextStepVisible;
			}
			set
			{
				_isNextStepVisible = value;
				OnPropertyChanged(nameof(IsNextStepVisible));
			}
		}


		public bool IsAddApiaryVisible
		{
			get
			{
				return _isAddApiaryVisible;
			}
			set
			{
				_isAddApiaryVisible = value;
				OnPropertyChanged(nameof(IsAddApiaryVisible));

			}
		}

		public bool IsListEnabled
		{
			get
			{
				return _isListEnabled;
			}
			set
			{
				_isListEnabled = value;
				OnPropertyChanged(nameof(IsListEnabled));
			}
		}

		public ObservableCollection<Apiary> ApiaryList
		{
			get
			{
				return _apiaryList;
			}
			set
			{
				_apiaryList = value;
				OnPropertyChanged(nameof(ApiaryList));
			}
		}

		public Apiary SelectedItem
		{
			get
			{
				return _selectedItem;
			}
			set
			{
				_selectedItem = value;
				OnPropertyChanged(nameof(SelectedItem));
				IsNextStepVisible = true;
			}
		}



		public CreatorSelectApiaryModel(CreatorSelectApiary view)
		{
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				var qb = scope.Resolve<IQueryBus>();
				ApiaryList = new ObservableCollection<Apiary>(qb.Process<GetFullListOf, List<object>>(new GetFullListOf(typeof(Apiary))).Cast<Apiary>().ToList());

				NextStep = new Command((obj) =>
				{
					using (var scope2 = IoC.container.BeginLifetimeScope())
					{
						var creator = scope2.Resolve<Creator>();
						creator.setApiaryContext(SelectedItem);
						IsListEnabled = false;
						IsAddApiaryVisible = false;
						IsNextStepVisible = false;
						creator.nextStep();
					}
				});
				AddApiary = new Command((obj) => 
				{
					using (var scope2 = IoC.container.BeginLifetimeScope())
					{
						var creator = scope2.Resolve<Creator>();
						creator.replaceStep(new CreatorAddApiary());
					}
				});
			}
		}
	}
}
