using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
namespace MojaPasieka.DataModel
{
	/// <summary>
	/// Typ historii ula
	/// </summary>
	[Table("tb_beehivehistorytype")]
	public class BeeHiveHistoryType : DataModelBase, IDataModel, IDataModelSelfInit
	{
		

		private int _bhht_id;
		private string _bhht_name;
		private BeeHiveHistoryTypeMain _bhht_main;
		private DateTime _bhht_timestamp;

		/// <summary>
		/// Id wpisu typu historii ula
		/// </summary>
		/// <value>The bhht identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int bhht_id
		{
			get
			{
				return _bhht_id;
			}

			set
			{
				_bhht_id = value;
				OnPropertyChanged(nameof(bhht_id));
			}
		}

		/// <summary>
		/// Nazwa elementu typu historii ula
		/// </summary>
		/// <value>The name of the bhht.</value>
		public string bhht_name
		{
			get
			{
				return _bhht_name;
			}

			set
			{
				_bhht_name = value;
				OnPropertyChanged(nameof(bhht_name));
			}
		}

		/// <summary>
		/// Timestamp
		/// </summary>
		/// <value>The bhht timestamp.</value>
		public DateTime bhht_timestamp
		{
			get
			{
				return _bhht_timestamp;
			}

			set
			{
				_bhht_timestamp = value;
				OnPropertyChanged(nameof(bhht_timestamp));
			}
		}
		/// <summary>
		/// Najważniejsze wpisy z historii
		/// </summary>
		/// <value>The bhht main.</value>
		public BeeHiveHistoryTypeMain bhht_main
		{
			get
			{
				return _bhht_main;
			}

			set
			{
				_bhht_main = value;
				OnPropertyChanged(nameof(bhht_main));
			}
		}

		public void fillWithData(SQLiteConnection database)
		{
			var res =  database.ExecuteScalar<int>("SELECT COUNT(bhht_id) FROM tb_beehivehistorytype");
			if (res == 0)
			{
				 database.InsertAll(new List<BeeHiveHistoryType> { 
				
					new BeeHiveHistoryType {
						bhht_name="Nowy",
						bhht_main= BeeHiveHistoryTypeMain.NEW,
						bhht_timestamp = DateTime.Now
					},
					new BeeHiveHistoryType {
						bhht_name="Konserwacja",
						bhht_main= BeeHiveHistoryTypeMain.CONSERVATION,
						bhht_timestamp = DateTime.Now
					},
					new BeeHiveHistoryType {
						bhht_name="Włożona wkładka dennicowa",
						bhht_main= BeeHiveHistoryTypeMain.BOTTOM_INSERT_ADDED,
						bhht_timestamp = DateTime.Now
					},
					new BeeHiveHistoryType {
						bhht_name="Wyciągnięta wkładka dennicowa",
						bhht_main= BeeHiveHistoryTypeMain.BOTTOM_INSERT_REMOVED,
						bhht_timestamp = DateTime.Now
					},
					new BeeHiveHistoryType {
						bhht_name="Dezynfekcja",
						bhht_main= BeeHiveHistoryTypeMain.DISINFECTION,
						bhht_timestamp = DateTime.Now
					},
					new BeeHiveHistoryType {
						bhht_name="Utylizacja",
						bhht_main= BeeHiveHistoryTypeMain.UTILIZATION,
						bhht_timestamp = DateTime.Now
					}
				
				});
			}
		}
	}

	public enum BeeHiveHistoryTypeMain
	{
		[EnumName("Nowy")]
		NEW = 1,

		[EnumName("Dodano władnę dennicową")]
		BOTTOM_INSERT_ADDED = 2,

		[EnumName("Usunięto wkładkę dennicową")]
		BOTTOM_INSERT_REMOVED = 3,

		[EnumName("Dezynfekcja")]
		DISINFECTION = 4,

		[EnumName("Utylizacja")]
		UTILIZATION = 5,

		[EnumName("Konserwacja")]
		CONSERVATION = 6
	}
}
