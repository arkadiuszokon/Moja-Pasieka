using System;
using System.Collections.Generic;
using SQLite;

namespace MojaPasieka.DataModel
{
	[Table("tb_queenbee")]
	public class QueenBee : DataModelBase, IDataModel
	{

		/// <summary>
		/// Ostatnia cyfra roku - przełozenie na kolor opalitki
		/// </summary>
		public static Dictionary<QueenBeeColor, int[]> queenBeeColorYears = new Dictionary<QueenBeeColor, int[]>
		{
			{QueenBeeColor.WHITE, new int[] {1,6}} ,
			{QueenBeeColor.YELLOW, new int[] {2,7}},
			{QueenBeeColor.RED, new int[] {3,8}},
			{QueenBeeColor.GREEN, new int[] {4,9}},
			{QueenBeeColor.BLUE, new int[] {5,0}}
		};

		private int _mt_id;
		private string _mt_name;
		private QueenBeeColor _mt_color;
		private int _mt_year;
		private int _mt_rs_id;
		private QueenBeeSource _mt_source;
		private int _mt_rd_idraised;
		private int _mt_mt_id;
		private int _mt_rd_idfather;
		private int _mt_hd_id;
		private string _mt_desc;
		private DateTime _mt_timestamp;

		/// <summary>
		/// Id matki
		/// </summary>
		/// <value>The mt identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int mt_id
		{
			get
			{
				return _mt_id;
			}

			set
			{
				_mt_id = value;
				OnPropertyChanged(nameof(mt_id));
			}
		}

		/// <summary>
		/// Nazwa matki
		/// </summary>
		/// <value>The name of the mt.</value>
		public string mt_name
		{
			get
			{
				return _mt_name;
			}

			set
			{
				_mt_name = value;
				OnPropertyChanged(nameof(mt_name));
			}
		}

		/// <summary>
		/// Kolor opalitka
		/// </summary>
		/// <value>The color of the mt.</value>
		public QueenBeeColor mt_color
		{
			get
			{
				return _mt_color;
			}

			set
			{
				_mt_color = value;
				OnPropertyChanged(nameof(mt_color));
			}
		}

		/// <summary>
		/// Rok matki
		/// </summary>
		/// <value>The mt year.</value>
		public int mt_year
		{
			get
			{
				return _mt_year;
			}

			set
			{
				_mt_year = value;
				OnPropertyChanged(nameof(mt_year));
			}
		}

		/// <summary>
		/// id rasy matki
		/// </summary>
		/// <value>The mt rs identifier.</value>
		[Indexed]
		public int mt_rs_id
		{
			get
			{
				return _mt_rs_id;
			}

			set
			{
				_mt_rs_id = value;
				OnPropertyChanged(nameof(mt_rs_id));
			}
		}

		/// <summary>
		/// Źródło pozyskania matki
		/// </summary>
		/// <value>The mt source.</value>
		public QueenBeeSource mt_source
		{
			get
			{
				return _mt_source;
			}

			set
			{
				_mt_source = value;
				OnPropertyChanged(nameof(mt_source));
			}
		}

		/// <summary>
		/// Id rodziny wychowującej
		/// Uzupełniane w przypadku własnej chodowli
		/// </summary>
		/// <value>The mt rd idraised.</value>
		[Indexed]
		public int mt_rd_idraised
		{
			get
			{
				return _mt_rd_idraised;
			}

			set
			{
				_mt_rd_idraised = value;
				OnPropertyChanged(nameof(mt_rd_idraised));
			}
		}

		/// <summary>
		/// Strona mateczna
		/// uzupełniane w przypadku własnej chodowli
		/// </summary>
		/// <value>The mt mt identifier.</value>
		[Indexed]
		public int mt_mt_id
		{
			get
			{
				return _mt_mt_id;
			}

			set
			{
				_mt_mt_id = value;
				OnPropertyChanged(nameof(mt_mt_id));
			}
		}

		/// <summary>
		/// Strona ojcowska
		/// uzupełniane w przypadku własnej chodowli
		/// </summary>
		/// <value>The mt rd idfather.</value>
		[Indexed]
		public int mt_rd_idfather
		{
			get
			{
				return _mt_rd_idfather;
			}

			set
			{
				_mt_rd_idfather = value;
				OnPropertyChanged(nameof(mt_rd_idfather));
			}
		}

		/// <summary>
		/// Id hodowcy u którego kupiono matkę
		/// uzupełniane w przypadku zakupu matki z zewnatrz
		/// </summary>
		/// <value>The mt hd identifier.</value>
		[Indexed]
		public int mt_hd_id
		{
			get
			{
				return _mt_hd_id;
			}

			set
			{
				_mt_hd_id = value;
				OnPropertyChanged(nameof(mt_hd_id));
			}
		}

		/// <summary>
		/// DOdatkowy opis
		/// </summary>
		/// <value>The mt desc.</value>
		public string mt_desc
		{
			get
			{
				return _mt_desc;
			}

			set
			{
				_mt_desc = value;
				OnPropertyChanged(nameof(mt_desc));
			}
		}

		public DateTime mt_timestamp
		{
			get
			{
				return _mt_timestamp;
			}

			set
			{
				_mt_timestamp = value;
				OnPropertyChanged(nameof(mt_timestamp));
			}
		}

	}


	/// <summary>
	/// Źródło pozyskania matki
	/// </summary>
	public enum QueenBeeSource
	{
		OWN_BREEDING = 1,
		EXTERNAL_PURCHASE = 2,
		SWARM_QUEEN = 3,
		OTHER = 4
	}

	/// <summary>
	/// Kolory opalitek
	/// </summary>
	public enum QueenBeeColor
	{
		WHITE = 1,
		YELLOW = 2,
		RED = 3,
		GREEN = 4,
		BLUE = 5
	}

}
