using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Autofac;
using MojaPasieka.cqrs;
using MojaPasieka.Utils;
using MojaPasieka.DataModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MojaPasieka.View
{
	public class CreatorMakeBeeHivesModel : ViewModelBase, IViewModel
	{
		private ObservableCollection<FrameType> _framesTypes;
		private ObservableCollection<FrameType> _framesTypesHalf;
		private ObservableCollection<EnumDictionaryObject> _beeHiveTypes;
		private ObservableCollection<EnumDictionaryObject> _beeHiveMaterials;
		private ObservableCollection<EnumDictionaryObject> _beeHivesBottoms;
		private ObservableCollection<EnumDictionaryObject> _beeHivesTop;
		private FrameType _selectedFrameType;
		private FrameType _selectedFrameTypeHalf;
		private INotification notifyService;
		private EnumDictionaryObject _selectedBeeHiveType;
		private EnumDictionaryObject _selectedBeeHiveMaterial;
		private EnumDictionaryObject _selectedBeeHiveBottom;
		private EnumDictionaryObject _selectedBeeHiveTop;
		private string _numerationBegin;
		private int _numerationStart = 1;
		private int _framesCount = 10;
		private bool _isBeeHiveBodyVisible = false;
		private int _beeHiveBodyCount = 1;
		private bool _addBeeHiveBodyHalf = false;
		private int _beeHiveCount;
		private Command _addBeeHives;
		private bool _showLoading = false;
		private bool _showContent = true;
		private bool _isNextStepVisible = true;
		private bool _isReadyVisible = false;
		private Command _nextStep;

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

		public Command AddBeeHives
		{
			get
			{
				return _addBeeHives;
			}
			set
			{
				_addBeeHives = value;
				OnPropertyChanged(nameof(AddBeeHives));
			}
		}

		public int BeeHiveCount
		{
			get
			{
				return _beeHiveCount;
			}
			set
			{
				_beeHiveCount = value;
				OnPropertyChanged(nameof(BeeHiveCount));
				if (value > 200)
				{
					notifyService.showAlert("Hej", "Wow, niezła pasieka!");
				}
			}
		}

		public bool AddBeeHiveBodyHalf
		{
			get
			{
				return _addBeeHiveBodyHalf;
			}
			set
			{
				_addBeeHiveBodyHalf = value;
				OnPropertyChanged(nameof(AddBeeHiveBodyHalf));
			}
		}


		public int BeeHiveBodyCount
		{
			get
			{
				return _beeHiveBodyCount;
			}
			set
			{
				if (SelectedBeeHiveType != null && SelectedBeeHiveType.Id == (int)BeeHiveType.HORIZONTAL)
				{
					if (value > 1)
					{
						notifyService.showAlert("Błąd", "Nie możesz dodać do leżaka więcej niż jeden korpus");
					}
					else
					{
						_beeHiveBodyCount = value;
						OnPropertyChanged(nameof(BeeHiveBodyCount));
					}
				}
				else
				{
					_beeHiveBodyCount = value;
					OnPropertyChanged(nameof(BeeHiveBodyCount));
				}
				if (value > 3)
				{
					notifyService.showAlert("Hej", "Niezła wieża, uważaj żeby się nie przewróciła ;)");
				}

			}
		}

		public bool IsBeeHiveBodyVisible
		{
			get
			{
				return _isBeeHiveBodyVisible;
			}
			set
			{
				_isBeeHiveBodyVisible = value;
				OnPropertyChanged(nameof(IsBeeHiveBodyVisible));
			}
		}

		public int FramesCount
		{
			get
			{
				return _framesCount;
			}
			set
			{
				
				_framesCount = value;
				OnPropertyChanged(nameof(FramesCount));

				if (value > 12)
				{
					notifyService.showAlert("Hej", "Więcej niż 12 ramek? Ale masz nietypowy korpus...");
				}

			}
		}

		public int NumerationStart
		{
			get
			{
				return _numerationStart;
			}
			set
			{
				_numerationStart = value;
				OnPropertyChanged(nameof(NumerationStart));
			}
		}

		public string NumerationBegin
		{
			get
			{
				return _numerationBegin;
			}
			set
			{
				_numerationBegin = value;
				OnPropertyChanged(nameof(NumerationBegin));
			}
		}

		public EnumDictionaryObject SelectedBeeHiveTop
		{
			get
			{
				return _selectedBeeHiveTop;
			}
			set
			{
				_selectedBeeHiveTop = value;
				OnPropertyChanged(nameof(SelectedBeeHiveTop));
			}
		}

		public EnumDictionaryObject SelectedBeeHiveBottom
		{
			get
			{
				return _selectedBeeHiveBottom;
			}
			set
			{
				_selectedBeeHiveBottom = value;
				OnPropertyChanged(nameof(SelectedBeeHiveBottom));
			}
		}

		public EnumDictionaryObject SelectedBeeHiveMaterial
		{
			get
			{
				return _selectedBeeHiveMaterial;
			}
			set
			{
				_selectedBeeHiveMaterial = value;
				OnPropertyChanged(nameof(SelectedBeeHiveMaterial));
			}
		}

		public EnumDictionaryObject SelectedBeeHiveType
		{
			get
			{
				return _selectedBeeHiveType;
			}
			set
			{
				_selectedBeeHiveType = value;
				OnPropertyChanged(nameof(SelectedBeeHiveType));
				if (value.Id == (int)BeeHiveType.HORIZONTAL)
				{
					IsBeeHiveBodyVisible = true;
					if (BeeHiveBodyCount > 1)
					{
						BeeHiveBodyCount = 1;
					}
				}
				else if (value.Id == (int)BeeHiveType.VERTICAL)
				{
					IsBeeHiveBodyVisible = true;
				}
				else
				{
					IsBeeHiveBodyVisible = false;
				}
			}
		}

		public FrameType SelectedFrameType
		{
			get
			{
				return _selectedFrameType;
			}
			set
			{
				if (_selectedFrameTypeHalf != null && value != null)
				{
					if (_selectedFrameTypeHalf.ft_width == value.ft_width)
					{
						_selectedFrameType = value;
					}
					else
					{
						notifyService.showAlert("Błąd", "Ramka nadstawkowa i główna muszą być tego samego typu");
					}
				}
				else
				{
					_selectedFrameType = value;
				}
				OnPropertyChanged(nameof(SelectedFrameType));
			}
		}

		public FrameType SelectedFrameTypeHalf
		{
			get
			{
				return _selectedFrameTypeHalf;
			}
			set
			{
				if (_selectedFrameType != null && value != null)
				{
					if (_selectedFrameType.ft_width == value.ft_width)
					{
						_selectedFrameTypeHalf = value;
					}
					else
					{
						notifyService.showAlert("Błąd", "Ramka nadstawkowa i główna muszą być tego samego typu");
					}
				}
				else
				{
					_selectedFrameTypeHalf = value;
				}
				OnPropertyChanged(nameof(SelectedFrameTypeHalf));
			}
		}

		public ObservableCollection<FrameType> FramesTypes
		{
			get
			{
				return _framesTypes;
			}
			set
			{
				_framesTypes = value;
				OnPropertyChanged(nameof(FramesTypes));
			}
		}

		public ObservableCollection<FrameType> FramesTypesHalf
		{
			get
			{
				return _framesTypesHalf;
			}
			set
			{
				_framesTypesHalf = value;
				OnPropertyChanged(nameof(FramesTypesHalf));
			}
		}

		public ObservableCollection<EnumDictionaryObject> BeeHiveTypes
		{
			get
			{
				return _beeHiveTypes;
			}
			set
			{
				_beeHiveTypes = value;
				OnPropertyChanged(nameof(BeeHiveTypes));
			}
		}

		public ObservableCollection<EnumDictionaryObject> BeeHiveMaterials
		{
			get
			{
				return _beeHiveMaterials;
			}
			set
			{
				_beeHiveMaterials = value;
				OnPropertyChanged(nameof(BeeHiveMaterials));
			}
		}

		public ObservableCollection<EnumDictionaryObject> BeeHiveBottoms
		{
			get
			{
				return _beeHivesBottoms;
			}
			set
			{
				_beeHivesBottoms = value;
				OnPropertyChanged(nameof(BeeHiveBottoms));
			}
		}

		public ObservableCollection<EnumDictionaryObject> BeeHiveTops
		{
			get
			{
				return _beeHivesTop;
			}
			set
			{
				_beeHivesTop = value;
				OnPropertyChanged(nameof(BeeHiveTops));
			}
		}

		public CreatorMakeBeeHivesModel(CreatorMakeBeeHives view, INotification notificationService)
		{
			this.notifyService = notificationService;
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				var qb = scope.Resolve<IQueryBus>();
				FramesTypes = new ObservableCollection<FrameType>(qb.Process<GetFrameTypesByMainType, List<FrameType>>(new GetFrameTypesByMainType(FrameTypeMain.REGULAR)));
				FramesTypesHalf = new ObservableCollection<FrameType>(qb.Process<GetFrameTypesByMainType, List<FrameType>>(new GetFrameTypesByMainType(FrameTypeMain.REGULAR_HALF)));
				BeeHiveTypes = new ObservableCollection<EnumDictionaryObject>(EnumHelper.ReturnListFromEnum<BeeHiveType>());
				BeeHiveMaterials = new ObservableCollection<EnumDictionaryObject>(EnumHelper.ReturnListFromEnum<BeeHiveMaterialType>());
				BeeHiveBottoms = new ObservableCollection<EnumDictionaryObject>(EnumHelper.ReturnListFromEnum<BeeHiveBottomType>());
				BeeHiveTops = new ObservableCollection<EnumDictionaryObject>(EnumHelper.ReturnListFromEnum<BeeHiveTopType>());
				NextStep = new Command((obj) => 
				{
					using (var scope2 = IoC.container.BeginLifetimeScope())
					{
						IsNextStepVisible = false;
						var creator = scope2.Resolve<Creator>();
						creator.nextStep();
					}
				});
				AddBeeHives = new Command((obj) => 
				{
					if (SelectedFrameType == null)
					{
						notifyService.showAlert("Błąd", "Wybierz typ ramki");
						return;
					}
					if (SelectedBeeHiveType == null)
					{
						notifyService.showAlert("Błąd", "Wybierz typ ula");
						return;
					}
					if (SelectedBeeHiveMaterial == null)
					{
						notifyService.showAlert("Błąd", "Wybierz materiał ula");
						return;
					}
					if (SelectedBeeHiveBottom == null)
					{
						notifyService.showAlert("Błąd", "Wybierz rodzaj dennicy");
						return;
					}
					if (SelectedBeeHiveTop == null)
					{
						notifyService.showAlert("Błąd", "Wybierz typ nakrycia");
						return;
					}
					if (FramesCount == 0)
					{
						notifyService.showAlert("Błąd", "Podaj poprawną liczbę ramek");
						return;
					}
					if (BeeHiveCount == 0)
					{
						notifyService.showAlert("Błąd", "Podaj poprawną ilość uli do dodania");
						return;
					}
					if (IsBeeHiveBodyVisible)
					{
						if (BeeHiveBodyCount == 0)
						{
							notifyService.showAlert("Błąd", "Podaj poprawną ilość kospusów");
							return;
						}
						if (AddBeeHiveBodyHalf)
						{
							if (SelectedFrameTypeHalf == null)
							{
								notifyService.showAlert("Błąd", "Wybierz typ ramki nadstawkowej");
								return;
							}
						}
					}
					ShowLoading = true;
					ShowContent = false;
					try
					{
						Task.Run(async () =>
						{

							using (var scope2 = IoC.container.BeginLifetimeScope())
							{
								var beeHivesAdded = new List<BeeHive>();

								var cb = scope2.Resolve<ICommandBus>();
								var creator = scope2.Resolve<Creator>();

								var numeration = NumerationStart;

								for (int i = 0; i < BeeHiveCount; i++)
								{
									var beeHiveName = "";
									if (NumerationBegin != String.Empty)
									{
										beeHiveName = NumerationBegin + " ";
									}
									beeHiveName += numeration.ToString();
									var bh = new BeeHive
									{
										bh_ap_id = creator.apiary.ap_id,
										bh_bottomtype = EnumHelper.getEnum<BeeHiveBottomType>(SelectedBeeHiveBottom.Id),
										bh_desc = "",
										bh_material = EnumHelper.getEnum<BeeHiveMaterialType>(SelectedBeeHiveMaterial.Id),
										bh_name = beeHiveName,
										bh_paint = "",
										bh_type = EnumHelper.getEnum<BeeHiveType>(SelectedBeeHiveType.Id),
										bh_toptype = EnumHelper.getEnum<BeeHiveTopType>(SelectedBeeHiveTop.Id),
										bh_timestamp = DateTime.Now
									};
									await cb.SendCommandAsync<AddBeeHive>(new AddBeeHive(bh));
									numeration++;
									beeHivesAdded.Add(bh);
								}
								if (beeHivesAdded.Count > 0)
								{
									var bodysAdded = new List<BeeHiveBody>();

									for (int i = 0; i < beeHivesAdded.Count; i++)
									{
										if (IsBeeHiveBodyVisible)
										{
											for (int j = 0; j < BeeHiveBodyCount; j++)
											{
												var bhb = new BeeHiveBody
												{
													bhb_bh_id = beeHivesAdded[i].bh_id,
													bhb_framescount = FramesCount,
													bhb_ft_id = SelectedFrameType.ft_id,
													bhb_desc = "",
													bhb_name = beeHivesAdded[i].bh_name + " " + (j + 1).ToString(),
													bhb_order = j + 1,
													bhb_wh_id = 0,
													bhb_paint = "",
													bhb_timestamp = DateTime.Now
												};
												await cb.SendCommandAsync<AddBeeHiveBody>(new AddBeeHiveBody(bhb));
												bodysAdded.Add(bhb);
											}
											if (AddBeeHiveBodyHalf)
											{
												var bhb = new BeeHiveBody
												{
													bhb_bh_id = beeHivesAdded[i].bh_id,
													bhb_framescount = FramesCount,
													bhb_ft_id = SelectedFrameTypeHalf.ft_id,
													bhb_desc = "",
													bhb_name = beeHivesAdded[i].bh_name + " " + (BeeHiveBodyCount + 1).ToString(),
													bhb_order = BeeHiveBodyCount + 1,
													bhb_wh_id = 0,
													bhb_paint = "",
													bhb_timestamp = DateTime.Now
												};
												await cb.SendCommandAsync<AddBeeHiveBody>(new AddBeeHiveBody(bhb));
												bodysAdded.Add(bhb);
											}
										}
										else
										{
											var bhb = new BeeHiveBody
											{
												bhb_bh_id = beeHivesAdded[i].bh_id,
												bhb_framescount = FramesCount,
												bhb_ft_id = SelectedFrameType.ft_id,
												bhb_desc = "",
												bhb_name = beeHivesAdded[i].bh_name + " 1",
												bhb_order = 1,
												bhb_wh_id = 0,
												bhb_paint = "",
												bhb_timestamp = DateTime.Now
											};
											await cb.SendCommandAsync<AddBeeHiveBody>(new AddBeeHiveBody(bhb));
											bodysAdded.Add(bhb);
										}
									}
									// dodaliśmy korpusy dodajemy ramki w transakcji
									scope2.Resolve<SQLite.SQLiteConnection>().BeginTransaction();
									for (int i = 0; i < bodysAdded.Count; i++)
									{
										for (int j = 0; j < bodysAdded[i].bhb_framescount; j++)
										{
											var fr = new DataModel.Frame
											{
												fr_bhb_id = bodysAdded[i].bhb_id,
												fr_color = FrameColor.YELLOW,
												fr_desc = "",
												fr_ft_id = bodysAdded[i].bhb_ft_id,
												fr_order = j+1,
												fr_isolated = false,
												fr_wh_id = 0,
												fr_timestamp = DateTime.Now
											};
											await cb.SendCommandAsync<AddFrame>(new AddFrame(fr));
										}
									}
									scope2.Resolve<SQLite.SQLiteConnection>().Commit();
								}

								ShowLoading = false;
								IsReadyVisible = true;
							}

						});
					}
					catch (Exception ex)
					{
						Debug.WriteLine(ex.ToString());
					}

				});
			}
		}
	}
}
