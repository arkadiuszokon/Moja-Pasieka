using System;
using System.Collections.Generic;
using SQLite;
namespace MojaPasieka.DataModel
{
	[Table("tb_frame")]
	public class Frame : DataModelBase, IDataModel
	{
		public static Dictionary<FrameColor, string> frameColorName = new Dictionary<FrameColor, string> {
			{FrameColor.LIGHT_YELLOW, "Jasnożółty, białawy"},
			{FrameColor.YELLOW, "Żółty"},
			{FrameColor.LIGHT_BROWN, "Jasnobrązowy"},
			{FrameColor.BROWN, "Brązowy"},
			{FrameColor.DARK_BROWN, "Ciemnobrązowy"},
			{FrameColor.BLACK, "Czarny"}
		};


		/*new Column("rm_id", "INTEGER", "", true, true, true), //id ramki
				new Column("rm_rt_id", "INTEGER", "", true), //id typu
				new Column("rm_kr_id", "INTEGER", "", true), //id korpusu
				new Column("rm_mg_id", "INTEGER", "", true), //id magazynu
				new Column("rm_desc", "TEXT", "", false), //opis
				new Column("rm_rk_id", "INTEGER", "", true), //id koloru ramki
				new Column("rm_isolated", "TINYINT", "2", true), //czy ramka jest w izolatorze
				new Column("rm_order", "INTEGER", "", true), //kolejnosc
				new Column("rm_highlight", "VARCHAR", "255", false), // wyróżnienie ramki
				new Column("rm_dategen", "INTEGER", "", true) //data zrobienia/wygenerowania*/
		private int _fr_id;
		private int _fr_ft_id;
		private int _fr_bhb_id;
		private int _fr_wh_id;
		private FrameColor _fr_color;
		private bool _fr_isolated;
		private int _fr_order;
		private string _fr_desc;
		private DateTime _fr_timestamp;

		/// <summary>
		/// Id ramki
		/// </summary>
		/// <value>The fr identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int fr_id
		{
			get
			{
				return _fr_id;
			}

			set
			{
				_fr_id = value;
				OnPropertyChanged(nameof(fr_id));
			}
		}

		/// <summary>
		/// id typu ramki
		/// </summary>
		/// <value>The fr ft identifier.</value>
		[Indexed]
		public int fr_ft_id
		{
			get
			{
				return _fr_ft_id;
			}

			set
			{
				_fr_ft_id = value;
				OnPropertyChanged(nameof(fr_ft_id));
			}
		}

		/// <summary>
		/// Id korpusu w którym jest ramka
		/// </summary>
		/// <value>null jeśli ramka jest w magazynie</value>
		[Indexed]
		public int fr_bhb_id
		{
			get
			{
				return _fr_bhb_id;
			}

			set
			{
				_fr_bhb_id = value;
				OnPropertyChanged(nameof(fr_bhb_id));
			}
		}

		/// <summary>
		/// Id magazynu
		/// </summary>
		/// <value>null jeżeli jest w korpusie</value>
		[Indexed]
		public int fr_wh_id
		{
			get
			{
				return _fr_wh_id;
			}

			set
			{
				_fr_wh_id = value;
				OnPropertyChanged(nameof(fr_wh_id));
			}
		}

		/// <summary>
		/// Kolor ramki
		/// </summary>
		/// <value>The color of the fr.</value>
		public FrameColor fr_color
		{
			get
			{
				return _fr_color;
			}

			set
			{
				_fr_color = value;
				OnPropertyChanged(nameof(fr_color));
			}
		}

		/// <summary>
		/// Czy ramka jest w izolatorze
		/// </summary>
		/// <value><c>true</c> if fr isolated; otherwise, <c>false</c>.</value>
		public bool fr_isolated
		{
			get
			{
				return _fr_isolated;
			}

			set
			{
				_fr_isolated = value;
				OnPropertyChanged(nameof(fr_isolated));
			}
		}

		/// <summary>
		/// Kolejność w korpusie
		/// </summary>
		/// <value>The fr order.</value>
		public int fr_order
		{
			get
			{
				return _fr_order;
			}

			set
			{
				_fr_order = value;
				OnPropertyChanged(nameof(fr_order));
			}
		}

		/// <summary>
		/// Dodatkowy opis
		/// </summary>
		/// <value>The fr desc.</value>
		public string fr_desc
		{
			get
			{
				return _fr_desc;
			}

			set
			{
				_fr_desc = value;
				OnPropertyChanged(nameof(fr_desc));
			}
		}

		public DateTime fr_timestamp
		{
			get
			{
				return _fr_timestamp;
			}

			set
			{
				_fr_timestamp = value;
			}
		}
	}

	/// <summary>
	/// Kolory ramki
	/// </summary>
	public enum FrameColor
	{
		LIGHT_YELLOW = 1,
		YELLOW = 2,
		LIGHT_BROWN = 3,
		BROWN = 4,
		DARK_BROWN = 5,
		BLACK = 6
	}
}
