using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
namespace MojaPasieka.DataModel
{
	[Table("tb_medicine")]
	public class Medicine : DataModelBase, IDataModel, IDataModelSelfInit
	{
		public static Dictionary<MedicineUom, string> medicineUomName = new Dictionary<MedicineUom, string>
		{
			{MedicineUom.GRAM, "gram"},
			{MedicineUom.ML, "ml"},
			{MedicineUom.PACKAGE, "opak."},
			{MedicineUom.STRIPE, "pasek"},
			{MedicineUom.TABLETS, "tabletka"}
		};

		private int _md_id;
		private string _md_name;
		private string _md_desc;
		private MedicineUom _md_uom;
		private decimal _md_quan;
		private string _md_dosage;
		private DateTime _md_timestamp;

		/// <summary>
		/// Id lekarstwa
		/// </summary>
		/// <value>The md identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int md_id
		{
			get
			{
				return _md_id;
			}

			set
			{
				_md_id = value;
				OnPropertyChanged(nameof(md_id));
			}
		}

		/// <summary>
		/// Nazwa leku
		/// </summary>
		/// <value>The name of the md.</value>
		public string md_name
		{
			get
			{
				return _md_name;
			}

			set
			{
				_md_name = value;
				OnPropertyChanged(nameof(md_name));
			}
		}

		/// <summary>
		/// Opis leku/Substancja czynna
		/// </summary>
		/// <value>The md desc.</value>
		public string md_desc
		{
			get
			{
				return _md_desc;
			}

			set
			{
				_md_desc = value;
				OnPropertyChanged(nameof(md_desc));
			}
		}

		/// <summary>
		/// Jednostka miary
		/// </summary>
		/// <value>The md uom.</value>
		public MedicineUom md_uom
		{
			get
			{
				return _md_uom;
			}

			set
			{
				_md_uom = value;
				OnPropertyChanged(nameof(md_uom));
			}
		}

		/// <summary>
		/// Posiadana ilość
		/// </summary>
		/// <value>The md quan.</value>
		public decimal md_quan
		{
			get
			{
				return _md_quan;
			}

			set
			{
				_md_quan = value;
				OnPropertyChanged(nameof(md_quan));
			}
		}

		/// <summary>
		/// Dawkowanie
		/// </summary>
		/// <value>The md dosage.</value>
		public string md_dosage
		{
			get
			{
				return _md_dosage;
			}

			set
			{
				_md_dosage = value;
				OnPropertyChanged(nameof(md_dosage));
			}
		}

		public DateTime md_timestamp
		{
			get
			{
				return _md_timestamp;
			}

			set
			{
				_md_timestamp = value;
				OnPropertyChanged(nameof(md_timestamp));
			}
		}

		public async Task fillWithData(SQLiteAsyncConnection database)
		{
			var res = await database.ExecuteScalarAsync<int>("SELECT COUNT(md_id) FROM tb_medicine");
			if (res == 0)
			{
				await database.InsertAllAsync(new List<Medicine> {

					new Medicine{
						md_name = "Apiwarol",
						md_desc="Amitraza",
						md_uom = MedicineUom.TABLETS,
						md_quan = 0,
						md_dosage = "3-4 x co 4-6 dni jedna tabletka, nie odymiać pszczół przy temp. niższej niż +10°C",
						md_timestamp = DateTime.Now
					},
					new Medicine{
						md_name = "Biowar 500",
						md_desc="Amitraza",
						md_uom = MedicineUom.STRIPE,
						md_quan = 0,
						md_dosage = "2 paski na ul, max 6 tygodni",
						md_timestamp = DateTime.Now
					},
					new Medicine{
						md_name = "Baywarol",
						md_desc="Flumetryna",
						md_uom = MedicineUom.STRIPE,
						md_quan = 0,
						md_dosage = "4 paski na ul, 2-6 tygodni",
						md_timestamp = DateTime.Now
					},
					new Medicine{
						md_name = "Apiwarol",
						md_desc="Kwasy organiczne",
						md_uom = MedicineUom.ML,
						md_quan = 0,
						md_dosage = "Polewanie uliczek międzyramkowych",
						md_timestamp = DateTime.Now
					},
					new Medicine{
						md_name = "Beevital Hive Clean",
						md_desc="Kwasy organiczne",
						md_uom = MedicineUom.ML,
						md_quan = 0,
						md_dosage = "Polewanie uliczek międzyramkowych",
						md_timestamp = DateTime.Now
					},
					new Medicine{
						md_name = "Bienenwohl",
						md_desc="Kwasy organiczne",
						md_uom = MedicineUom.ML,
						md_quan = 0,
						md_dosage = "6-8 ml na rodzinę",
						md_timestamp = DateTime.Now
					},
					new Medicine{
						md_name = "Tymowarol",
						md_desc="Tymol",
						md_uom = MedicineUom.PACKAGE,
						md_quan = 0,
						md_dosage = "",
						md_timestamp = DateTime.Now
					},
					new Medicine{
						md_name = "Apiguard",
						md_desc="Tymol",
						md_uom = MedicineUom.PACKAGE,
						md_quan = 0,
						md_dosage = "2 tacki na rodzinę w ciągu 4-6 tygodni",
						md_timestamp = DateTime.Now
					},
					new Medicine{
						md_name = "Kwas mrówkowy",
						md_desc="Kwasy organiczne",
						md_uom = MedicineUom.ML,
						md_quan = 0,
						md_dosage = "",
						md_timestamp = DateTime.Now
					},
					new Medicine{
						md_name = "Perizin",
						md_desc="Kumafos",
						md_uom = MedicineUom.ML,
						md_quan = 0,
						md_dosage = "5 ml roztworu na 1 uliczkę",
						md_timestamp = DateTime.Now
					},
					new Medicine{
						md_name = "Kwas szczawiowy",
						md_desc="Kwasy organiczne",
						md_uom = MedicineUom.ML,
						md_quan = 0,
						md_dosage = "",
						md_timestamp = DateTime.Now
					},
					new Medicine{
						md_name = "Kwas mlekowy",
						md_desc="Kwasy organiczne",
						md_uom = MedicineUom.ML,
						md_quan = 0,
						md_dosage = "",
						md_timestamp = DateTime.Now
					}
				
				});
			}
		}
	}
			
	/// <summary>
	/// Enum z jednostkami miar lekarstw
	/// </summary>
	public enum MedicineUom
	{
		ML = 1,
		GRAM = 2,
		TABLETS = 3,
		PACKAGE = 4,
		STRIPE = 5
	}
}
