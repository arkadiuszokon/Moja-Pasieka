using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace MojaPasieka.DataModel
{
	/// <summary>
	/// Typ historii rodziny
	/// </summary>
	[Table("tb_beecolonyhistorytype")]
	public class BeeColonyHistoryType : DataModelBase, IDataModel, IDataModelSelfInit
	{


		private int _bcht_id;
		private string _bcht_name;
		private BeeColonyHistoryMain _bcht_main;
		private string _bcht_dataname;
		private DateTime _bcht_timestamp;

		/// <summary>
		/// Id typu
		/// </summary>
		/// <value>The bcht identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int bcht_id
		{
			get
			{
				return _bcht_id;
			}

			set
			{
				_bcht_id = value;
				OnPropertyChanged(nameof(bcht_id));
			}
		}

		/// <summary>
		/// Nazwa typu
		/// </summary>
		/// <value>The name of the bcht.</value>
		public string bcht_name
		{
			get
			{
				return _bcht_name;
			}

			set
			{
				_bcht_name = value;
				OnPropertyChanged(nameof(bcht_name));
			}
		}

		/// <summary>
		/// Nazwa pola danych
		/// </summary>
		/// <value>The bcht dataname.</value>
		public string bcht_dataname
		{
			get
			{
				return _bcht_dataname;
			}

			set
			{
				_bcht_dataname = value;
				OnPropertyChanged(nameof(bcht_dataname));
			}
		}


		public DateTime bcht_timestamp
		{
			get
			{
				return _bcht_timestamp;
			}

			set
			{
				_bcht_timestamp = value;
				OnPropertyChanged(nameof(bcht_timestamp));
			}
		}
		/// <summary>
		/// Czy jest to jeden z ważniejszych, zdefiniowanych wpisów
		/// </summary>
		/// <value>The bcht main.</value>
		public BeeColonyHistoryMain bcht_main
		{
			get
			{
				return _bcht_main;
			}

			set
			{
				_bcht_main = value;
				OnPropertyChanged(nameof(bcht_main));
			}
		}

		public void fillWithData(SQLiteConnection database)
		{
			var res = database.ExecuteScalar<int>("SELECT COUNT(bcht_id) FROM tb_beecolonyhistorytype");
			if (res == 0)
			{
				 database.InsertAll(new List<BeeColonyHistoryType> {
					new BeeColonyHistoryType{
						bcht_name="Nowa rodzina",
						bcht_main = BeeColonyHistoryMain.NEW_COLONY,
						bcht_dataname="Źródło rodziny",
						bcht_timestamp = DateTime.Now
					},
					new BeeColonyHistoryType{
						bcht_name="Poddanie matki",
						bcht_dataname="Źródło matki",
						bcht_timestamp = DateTime.Now
					},
					new BeeColonyHistoryType{
						bcht_name="Rozpoczęcie czerwienia przez matkę",
						bcht_dataname="",
						bcht_timestamp = DateTime.Now
					},
					new BeeColonyHistoryType{
						bcht_name="Brak matki",
						bcht_dataname="Przyczyna",
						bcht_timestamp = DateTime.Now
					},
					new BeeColonyHistoryType{
						bcht_name="Wyjście rójki",
						bcht_dataname="Numer rójki",
						bcht_timestamp = DateTime.Now
					},
					new BeeColonyHistoryType{
						bcht_name="Miodobranie",
						bcht_main= BeeColonyHistoryMain.HONEY_HARVEST,
						bcht_dataname="Numer miodobrania",
						bcht_timestamp = DateTime.Now
					},
					new BeeColonyHistoryType{
						bcht_name="Rabunek",
						bcht_dataname="Przyczyna",
						bcht_timestamp = DateTime.Now
					},
					new BeeColonyHistoryType{
						bcht_name="Oblot wiosenny",
						bcht_dataname="",
						bcht_timestamp = DateTime.Now
					},
					new BeeColonyHistoryType{
						bcht_name="Trutówki",
						bcht_dataname="",
						bcht_timestamp = DateTime.Now
					},
					new BeeColonyHistoryType{
						bcht_name="Osypanie rodziny",
						bcht_main=BeeColonyHistoryMain.DEAD_COLONY,
						bcht_dataname="Przyczyna",
						bcht_timestamp = DateTime.Now
					}

				});

			}
		}
	}

	public enum BeeColonyHistoryMain
	{
		[EnumName("Nowa rodzina")]
		NEW_COLONY = 1,
		[EnumName("Miodobranie")]
		HONEY_HARVEST = 2,
		[EnumName("Osypanie rodziny")]
		DEAD_COLONY = 3
	}
}
