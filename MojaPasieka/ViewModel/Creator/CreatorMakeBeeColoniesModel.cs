using System;
using MojaPasieka.DataModel;
using MojaPasieka.cqrs;
using Autofac;
using MojaPasieka.Utils;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using SQLite;

namespace MojaPasieka.View
{
	public class CreatorMakeBeeColoniesModel : ViewModelBase, IViewModel
	{
		private string _beeHivesAdded;
		private EnumDictionaryObject _selectedInspectType;
		private ObservableCollection<EnumDictionaryObject> _beeColonyInspectTypes;
		private DateTime _colonyDateCreated = DateTime.Now;
		private INotification notifyService;
		private BeeBreed _selectedBeeBreed;
		private ObservableCollection<BeeBreed> _beeBreeds;
		private int _queenBeeYear = DateTime.Now.Year;
		private string _queenBeeColor = "";
		private ObservableCollection<EnumDictionaryObject> _queenBeeSources;
		private EnumDictionaryObject _selectedQueenBeeSource;
		private bool _showLoading = false;
		private bool _showContent = true;
		private bool _isNextStepVisible = true;
		private bool _isReadyVisible = false;
		private Command _nextStep;
		private Command _addBeeColonies;
		private QueenBeeColor queenColor;

		public Command AddBeeColonies
		{
			get
			{
				return _addBeeColonies;
			}
			set
			{
				_addBeeColonies = value;
				OnPropertyChanged(nameof(AddBeeColonies));
			}
		}

		public Command NextStep
		{
			get
			{
				return _nextStep;
			}
			set
			{
				_nextStep = value;
				OnPropertyChanged(nameof(NextStep));
			}
		}

		public bool IsReadyVisible
		{
			get
			{
				return _isReadyVisible;
			}
			set
			{
				_isReadyVisible = value;
				OnPropertyChanged(nameof(IsReadyVisible));
			}
		}

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

		public bool ShowContent
		{
			get
			{
				return _showContent;
			}
			set
			{
				_showContent = value;
				OnPropertyChanged(nameof(ShowContent));
			}
		}

		public bool ShowLoading
		{
			get
			{
				return _showLoading;
			}
			set
			{
				_showLoading = value;
				OnPropertyChanged(nameof(ShowLoading));
			}
		}
		public EnumDictionaryObject SelectedQueenBeeSource
		{
			get
			{
				return _selectedQueenBeeSource;
			}
			set
			{
				_selectedQueenBeeSource = value;
				OnPropertyChanged(nameof(SelectedQueenBeeSource));
			}
		}

		public ObservableCollection<EnumDictionaryObject> QueenBeeSources
		{
			get
			{
				return _queenBeeSources;
			}
			set
			{
				_queenBeeSources = value;
				OnPropertyChanged(nameof(QueenBeeSources));
			}
		}

		public string QueenBeeColor
		{
			get
			{
				return _queenBeeColor;
			}
			set
			{
				_queenBeeColor = value;
				OnPropertyChanged(nameof(QueenBeeColor));
			}
		}

		public int QueenBeeYear
		{
			get
			{
				return _queenBeeYear;
			}
			set
			{
				if (value > DateTime.Now.Year)
				{
					notifyService.showAlert("Błąd", "Nie możesz wybrać roku matki w przyszłości");
				}
				else if(value.ToString().Length == 4)
				{
					_queenBeeYear = value;
					OnPropertyChanged(nameof(QueenBeeYear));
					queenColor = QueenBeeHelper.getColorByYear(value);
					QueenBeeColor = "(" + EnumNameAttribute.GetValue<QueenBeeColor>(queenColor) + ")";
				}
			}
		}

		public ObservableCollection<BeeBreed> BeeBreeds
		{
			get
			{
				return _beeBreeds;
			}
			set
			{
				_beeBreeds = value;
				OnPropertyChanged(nameof(BeeBreeds));
			}
		}

		public BeeBreed SelectedBeeBreed
		{
			get
			{
				return _selectedBeeBreed;
			}
			set
			{
				_selectedBeeBreed = value;
				OnPropertyChanged(nameof(SelectedBeeBreed));
			}
		}

		public DateTime ColonyDateCreated
		{
			get
			{
				return _colonyDateCreated;
			}
			set
			{
				if (value > DateTime.Now)
				{
					notifyService.showAlert("Błąd", "Nie możesz utworzyć rodzin w przyszłości");
				}
				else
				{
					_colonyDateCreated = value;
					OnPropertyChanged(nameof(ColonyDateCreated));
				}
			}
		}

		public ObservableCollection<EnumDictionaryObject> BeeColonyInspectTypes
		{
			get
			{
				return _beeColonyInspectTypes;
			}
			set
			{
				_beeColonyInspectTypes = value;
				OnPropertyChanged(nameof(BeeColonyInspectTypes));
			}
		}

		public EnumDictionaryObject SelectedInspectType
		{
			get
			{
				return _selectedInspectType;
			}
			set
			{
				_selectedInspectType = value;
				OnPropertyChanged(nameof(SelectedInspectType));
			}
		}

		public string BeeHivesAdded
		{
			get
			{
				return _beeHivesAdded;
			}
			set
			{
				_beeHivesAdded = value;
				OnPropertyChanged(nameof(BeeHivesAdded));
			}
		}

		public CreatorMakeBeeColoniesModel(INotification notificationService)
		{
			this.notifyService = notificationService;
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				var qb = scope.Resolve<IQueryBus>();
				var creator = scope.Resolve<Creator>();
				BeeHivesAdded = creator.getCountBeeHivesAdded().ToString();
				this.BeeColonyInspectTypes = new ObservableCollection<EnumDictionaryObject>(EnumHelper.ReturnListFromEnum<BeeColonyInspectedType>());
				BeeBreeds = new ObservableCollection<BeeBreed>(qb.Process<GetFullListOf, List<object>>(new GetFullListOf(typeof(BeeBreed))).Cast<BeeBreed>().ToList());
				QueenBeeSources = new ObservableCollection<EnumDictionaryObject>(EnumHelper.ReturnListFromEnum<QueenBeeSource>());
				NextStep = new Command((obj) =>
				{
					using (var scope2 = IoC.container.BeginLifetimeScope())
					{
						IsNextStepVisible = false;
						creator.nextStep();
					}
				});
				AddBeeColonies = new Command((obj) => 
				{
					if (SelectedInspectType == null)
					{
						notifyService.showAlert("Błąd", "Wybierz rodzaj przeglądów");
						return;
					}
					if (SelectedBeeBreed == null)
					{
						notifyService.showAlert("Błąd", "Wybierz rasę matki");
						return;
					}
					if (SelectedQueenBeeSource == null)
					{
						notifyService.showAlert("Błąd", "Wybierz rasę matki");
						return;
					}
					ShowLoading = true;
					ShowContent = false;

					Task.Run(async () =>
					{
						try
						{
							using (var scope2 = IoC.container.BeginLifetimeScope())
							{
								var cb = scope2.Resolve<ICommandBus>();
								var countToGenerate = creator.getCountBeeHivesAdded();

								var beeHivesAdded = creator.getBeeHivesAdded();
								var coloniesAdded = new List<BeeColony>();
								scope2.Resolve<SQLiteConnection>().BeginTransaction();
								for (int i = 0; i < countToGenerate; i++)
								{
									var bc = new BeeColony
									{
										bc_created = ColonyDateCreated,
										bc_desc = "",
										bc_inspectedtype = EnumHelper.getEnum<BeeColonyInspectedType>(SelectedInspectType.Id),
										bc_name = "Rodzina w ulu: " + beeHivesAdded[i].bh_name,
										bc_timestamp = DateTime.Now
									};
									await cb.SendCommandAsync<AddBeeColony>(new AddBeeColony(bc));
									coloniesAdded.Add(bc);
								}
								scope2.Resolve<SQLiteConnection>().Commit();
								BeeColonyHistoryType newColony = qb.Process<GetBeeColonyHistoryType, BeeColonyHistoryType>(new GetBeeColonyHistoryType(BeeColonyHistoryMain.NEW_COLONY));
								scope2.Resolve<SQLiteConnection>().BeginTransaction();
								for (var i = 0; i < coloniesAdded.Count; i++)
								{
									var bch = new BeeColonyHistory
									{
										bch_bc_id = coloniesAdded[i].bc_id,
										bch_note = "Wygenerowano w kreatorze",
										bch_data = "",
										bch_date = ColonyDateCreated,
										bch_timestamp = DateTime.Now,
										bch_bcht_id = newColony.bcht_id
									};
									await cb.SendCommandAsync<AddBeeColonyHistory>(new AddBeeColonyHistory(bch));

									var queen = new QueenBee
									{
										qb_alive = true,
										qb_bb_id = SelectedBeeBreed.bb_id,
										qb_bc_id = coloniesAdded[i].bc_id,
										qb_bc_idfather = 0,
										qb_bc_idraised = 0,
										qb_br_id = 0,
										qb_color = queenColor,
										qb_desc = "",
										qb_name = "Matka w ulu: " + beeHivesAdded[i].bh_name,
										qb_qb_id = 0,
										qb_source = EnumHelper.getEnum<QueenBeeSource>(SelectedQueenBeeSource.Id),
										qb_year = QueenBeeYear,
										qb_timestamp = DateTime.Now
									};
									await cb.SendCommandAsync<AddQueenBee>(new AddQueenBee(queen));
								}
								scope2.Resolve<SQLiteConnection>().Commit();
								ShowLoading = false;
								IsReadyVisible = true;
							}
						}
						catch (ValidationException ve)
						{
							if (ve.Result.Messages.Count > 0)
							{
								notifyService.showAlert("Błąd", String.Join("\n", ve.Result.Messages));
							}
							else
							{
								notifyService.showAlert("Błąd", "Wystąpił błąd walidacji");
							}
						}
						catch (Exception ex)
						{

						}
					});
				});
			}
		}
	}
}
