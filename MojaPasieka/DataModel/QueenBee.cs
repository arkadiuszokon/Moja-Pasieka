using System;
using System.Collections.Generic;
using SQLite;

namespace MojaPasieka.DataModel
{
	/// <summary>
	/// Królowa
	/// </summary>
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
	
		private int _qb_id;
		private string _qb_name;
		private QueenBeeColor _qb_color;
		private int _qb_year;
		private int _qb_rs_id;
		private QueenBeeSource _qb_source;
		private int _qb_bc_idraised;
		private int _qb_qb_id;
		private int _qb_bc_idfather;
		private int _qb_br_id;
		private string _qb_desc;
		private bool _qb_alive;
		private DateTime _qb_timestamp;

		/// <summary>
		/// Id matki
		/// </summary>
		/// <value>The qb identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int qb_id
		{
			get
			{
				return _qb_id;
			}

			set
			{
				_qb_id = value;
				OnPropertyChanged(nameof(qb_id));
			}
		}

		/// <summary>
		/// Nazwa matki
		/// </summary>
		/// <value>The name of the qb.</value>
		public string qb_name
		{
			get
			{
				return _qb_name;
			}

			set
			{
				_qb_name = value;
				OnPropertyChanged(nameof(qb_name));
			}
		}

		/// <summary>
		/// Kolor opalitka
		/// </summary>
		/// <value>The color of the qb.</value>
		public QueenBeeColor qb_color
		{
			get
			{
				return _qb_color;
			}

			set
			{
				_qb_color = value;
				OnPropertyChanged(nameof(qb_color));
			}
		}

		/// <summary>
		/// Rok matki
		/// </summary>
		/// <value>The qb year.</value>
		public int qb_year
		{
			get
			{
				return _qb_year;
			}

			set
			{
				_qb_year = value;
				OnPropertyChanged(nameof(qb_year));
			}
		}

		/// <summary>
		/// id rasy matki
		/// </summary>
		/// <value>The qb rs identifier.</value>
		[Indexed]
		public int qb_rs_id
		{
			get
			{
				return _qb_rs_id;
			}

			set
			{
				_qb_rs_id = value;
				OnPropertyChanged(nameof(qb_rs_id));
			}
		}

		/// <summary>
		/// Źródło pozyskania matki
		/// </summary>
		/// <value>The qb source.</value>
		public QueenBeeSource qb_source
		{
			get
			{
				return _qb_source;
			}

			set
			{
				_qb_source = value;
				OnPropertyChanged(nameof(qb_source));
			}
		}

		/// <summary>
		/// Id rodziny wychowującej
		/// Uzupełniane w przypadku własnej chodowli
		/// </summary>
		/// <value>The qb bc idraised.</value>
		[Indexed]
		public int qb_bc_idraised
		{
			get
			{
				return _qb_bc_idraised;
			}

			set
			{
				_qb_bc_idraised = value;
				OnPropertyChanged(nameof(qb_bc_idraised));
			}
		}

		/// <summary>
		/// Strona mateczna
		/// uzupełniane w przypadku własnej chodowli
		/// </summary>
		/// <value>The qb qb identifier.</value>
		[Indexed]
		public int qb_qb_id
		{
			get
			{
				return _qb_qb_id;
			}

			set
			{
				_qb_qb_id = value;
				OnPropertyChanged(nameof(qb_qb_id));
			}
		}

		/// <summary>
		/// Strona ojcowska
		/// uzupełniane w przypadku własnej chodowli
		/// </summary>
		/// <value>The qb bc idfather.</value>
		[Indexed]
		public int qb_bc_idfather
		{
			get
			{
				return _qb_bc_idfather;
			}

			set
			{
				_qb_bc_idfather = value;
				OnPropertyChanged(nameof(qb_bc_idfather));
			}
		}

		/// <summary>
		/// Id hodowcy u którego kupiono matkę
		/// uzupełniane w przypadku zakupu matki z zewnatrz
		/// </summary>
		/// <value>The qb hd identifier.</value>
		[Indexed]
		public int qb_br_id
		{
			get
			{
				return _qb_br_id;
			}

			set
			{
				_qb_br_id = value;
				OnPropertyChanged(nameof(qb_br_id));
			}
		}

		/// <summary>
		/// DOdatkowy opis
		/// </summary>
		/// <value>The qb desc.</value>
		public string qb_desc
		{
			get
			{
				return _qb_desc;
			}

			set
			{
				_qb_desc = value;
				OnPropertyChanged(nameof(qb_desc));
			}
		}

		public DateTime qb_timestamp
		{
			get
			{
				return _qb_timestamp;
			}

			set
			{
				_qb_timestamp = value;
				OnPropertyChanged(nameof(qb_timestamp));
			}
		}

		/// <summary>
		/// Czy matka jeszcze żyje
		/// </summary>
		/// <value><c>true</c> if qb alive; otherwise, <c>false</c>.</value>
		public bool qb_alive
		{
			get
			{
				return _qb_alive;
			}

			set
			{
				_qb_alive = value;
				OnPropertyChanged(nameof(qb_alive));
			}
		}
	}


	/// <summary>
	/// Źródło pozyskania matki
	/// </summary>
	public enum QueenBeeSource
	{
		[EnumName("Własna hodowla")]
		OWN_BREEDING = 1,

		[EnumName("Zakup wewnetrzny")]
		EXTERNAL_PURCHASE = 2,

		[EnumName("Matka rojowa")]
		SWARM_QUEEN = 3,

		[EnumName("Inne")]
		OTHER = 4
	}

	/// <summary>
	/// Kolory opalitek
	/// </summary>
	public enum QueenBeeColor
	{
		[EnumName("Biały"), EnumColor("#ffffff")]
		WHITE = 1,

		[EnumName("Żółty"), EnumColor("#FFEB3B")]
		YELLOW = 2,

		[EnumName("Czerwony"), EnumColor("#FF3D00")]
		RED = 3,

		[EnumName("Zielony"), EnumColor("#388E3C")]
		GREEN = 4,

		[EnumName("Niebieski"), EnumColor("#1565C0")]
		BLUE = 5
	}

}
