using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
namespace MojaPasieka.DataModel
{
	/// <summary>
	/// Rodzaj ramki
	/// </summary>
	[Table("tb_frametype")]
	public class FrameType : DataModelBase, IDataModel, IDataModelSelfInit
	{

		private int _ft_id;
		private string _ft_name;
		private FrameTypeMain _ft_type;
		private int _ft_width;
		private int _ft_height;
		private DateTime _ft_timestamp;

		/// <summary>
		/// Id typu ramki
		/// </summary>
		/// <value>The ft identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int ft_id
		{
			get
			{
				return _ft_id;
			}

			set
			{
				_ft_id = value;
				OnPropertyChanged(nameof(ft_id));
			}
		}

		/// <summary>
		/// Nazwa typu
		/// </summary>
		/// <value>The name of the ft.</value>
		public string ft_name
		{
			get
			{
				return _ft_name;
			}

			set
			{
				_ft_name = value;
				OnPropertyChanged(nameof(ft_name));
			}
		}

		/// <summary>
		/// Typ ramki z enuma FrameTypeMain
		/// </summary>
		/// <value>The type of the ft.</value>
		public FrameTypeMain ft_type
		{
			get
			{
				return _ft_type;
			}

			set
			{
				_ft_type = value;
				OnPropertyChanged(nameof(ft_type));
			}
		}


		public DateTime ft_timestamp
		{
			get
			{
				return _ft_timestamp;
			}

			set
			{
				_ft_timestamp = value;
			}
		}

		/// <summary>
		/// Długość w mm
		/// </summary>
		/// <value>The width of the fr.</value>
		public int ft_width
		{
			get
			{
				return _ft_width;
			}

			set
			{
				_ft_width = value;
				OnPropertyChanged(nameof(ft_width));
			}
		}

		/// <summary>
		/// Wysokość w mm
		/// </summary>
		/// <value>The height of the ft.</value>
		public int ft_height
		{
			get
			{
				return _ft_height;
			}

			set
			{
				_ft_height = value;
				OnPropertyChanged(nameof(ft_height));
			}
		}

		public void FillWithData(SQLiteConnection database)
		{
			var res = database.ExecuteScalar<int>("SELECT COUNT(ft_id) FROM tb_frametype");
			if (res == 0)
			{
				database.InsertAll(new List<FrameType>
				{
					new FrameType {
						ft_name = "Wielkopolska",
						ft_type = FrameTypeMain.REGULAR,
						ft_width = 360,
						ft_height = 260,
						ft_timestamp = DateTime.Now
					},
					new FrameType {
						ft_name = "Wielkopolska 1/2",
						ft_type = FrameTypeMain.REGULAR_HALF,
						ft_width = 360,
						ft_height = 130,
						ft_timestamp = DateTime.Now
					},
					new FrameType {
						ft_name = "Langstroth",
						ft_type = FrameTypeMain.REGULAR,
						ft_width = 448 ,
						ft_height = 232,
						ft_timestamp = DateTime.Now
					},
					new FrameType {
						ft_name = "Dadant",
						ft_type = FrameTypeMain.REGULAR,
						ft_width = 435,
						ft_height = 300,
						ft_timestamp = DateTime.Now
					},
					new FrameType {
						ft_name = "Dadant 1/2",
						ft_type = FrameTypeMain.REGULAR_HALF,
						ft_width = 435,
						ft_height = 145,
						ft_timestamp = DateTime.Now
					},
					new FrameType {
						ft_name = "Ostrowskiej",
						ft_type = FrameTypeMain.REGULAR,
						ft_width = 360,
						ft_height = 230,
						ft_timestamp = DateTime.Now
					},
					new FrameType {
						ft_name = "Warszawska poszerzana",
						ft_type = FrameTypeMain.REGULAR,
						ft_width = 300,
						ft_height = 435,
						ft_timestamp = DateTime.Now
					},
					new FrameType {
						ft_name = "Warszawska p. nadstawkowa",
						ft_type = FrameTypeMain.REGULAR_HALF,
						ft_width = 300,
						ft_height = 130,
						ft_timestamp = DateTime.Now
					},
					new FrameType {
						ft_name = "Warszawska",
						ft_type = FrameTypeMain.REGULAR,
						ft_width = 240,
						ft_height = 445,
						ft_timestamp = DateTime.Now
					},
					new FrameType {
						ft_name = "Warszawska nadstawkowa",
						ft_type = FrameTypeMain.REGULAR_HALF,
						ft_width = 240,
						ft_height = 130,
						ft_timestamp = DateTime.Now
					},
					new FrameType {
						ft_name = "Wielkopolska 18",
						ft_type = FrameTypeMain.REGULAR,
						ft_width = 360,
						ft_height = 180,
						ft_timestamp = DateTime.Now
					},
					new FrameType {
						ft_name = "Weselna",
						ft_type = FrameTypeMain.REGULAR,
						ft_width = 120,
						ft_height = 105,
						ft_timestamp = DateTime.Now
					},
					new FrameType {
						ft_name = "Ramka pracy",
						ft_type = FrameTypeMain.WORK,
						ft_width = 0,
						ft_height = 0,
						ft_timestamp = DateTime.Now
					},
					new FrameType {
						ft_name = "Ramka wychowująca",
						ft_type = FrameTypeMain.QUEEN_RAISING,
						ft_width = 0,
						ft_height = 0,
						ft_timestamp = DateTime.Now
					},
					new FrameType {
						ft_name = "Izolator ramkowy",
						ft_type = FrameTypeMain.INSULATOR,
						ft_width = 0,
						ft_height = 0,
						ft_timestamp = DateTime.Now
					},
					new FrameType {
						ft_name = "Izalator chmary",
						ft_type = FrameTypeMain.INSULATOR,
						ft_width = 0,
						ft_height = 0,
						ft_timestamp = DateTime.Now
					},
					new FrameType {
						ft_name = "Podkarmiaczka",
						ft_type = FrameTypeMain.FEEDER,
						ft_width = 0,
						ft_height = 0,
						ft_timestamp = DateTime.Now
					},
					new FrameType {
						ft_name = "Krata odgrodowa",
						ft_type = FrameTypeMain.EXCLUDER,
						ft_width = 0,
						ft_height = 0,
						ft_timestamp = DateTime.Now
					},
					new FrameType {
						ft_name = "Zatwór",
						ft_type = FrameTypeMain.STRAW_MAT,
						ft_width = 0,
						ft_height = 0,
						ft_timestamp = DateTime.Now
					}

				});
			}
		}
	}

	/// <summary>
	/// Podstawowe zastosowania ramki
	/// </summary>
	public enum FrameTypeMain
	{
		[EnumName("Zwykła ramka")]
		REGULAR = 1,

		[EnumName("Ramka nadstawkowa")]
		REGULAR_HALF = 2,

		[EnumName("Ramka pracy")]
		WORK = 3,

		[EnumName("Ramka wychowująca")]
		QUEEN_RAISING = 4,

		[EnumName("Izolator")]
		INSULATOR = 5,

		[EnumName("Podkarmiaczka")]
		FEEDER = 6,

		[EnumName("Krata odgrodowa")]
		EXCLUDER = 7,

		[EnumName("Zatwór")]
		STRAW_MAT = 8
	}
}
