using System;
using SQLite;
namespace MojaPasieka.DataModel
{
	[Table("tb_treatment")]
	public class Treatment : DataModelBase, IDataModel
	{
		/*new Column("lc_id", "INTEGER", "", true, true, true),
				new Column("lc_lk_id", "INTEGER", "", true), //id leku
				new Column("lc_rd_id", "INTEGER", "", true), //id rodziny
				new Column("lc_quan", "DECIMAL", "10,6", true), //ilość leku
				new Column("lc_start", "INTEGER", "", true), //rozpoczęcie leczenia
				new Column("lc_end", "INTEGER", "", true), //zakonczenie leczenia
				new Column("lc_effect", "VARCHAR", "100", false), //efekt leczenia
				new Column("lc_desc", "VARCHAR", "255", false) //dodatkowy opis
				*/

		private int _lc_id;
		private int _lc_lk_id;
		private int _lc_rd_id;
		private decimal _lc_quan;
		private DateTime _lc_start;
		private DateTime _lc_end;
		private string _lc_effect;
		private string _lc_desc;

		/// <summary>
		/// id leczenia
		/// </summary>
		/// <value>The lc identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int lc_id
		{
			get
			{
				return _lc_id;
			}

			set
			{
				_lc_id = value;
				OnPropertyChanged(nameof(lc_id));
			}
		}

		/// <summary>
		/// id zastosowanego leku
		/// </summary>
		/// <value>The lc lk identifier.</value>
		[Indexed]
		public int lc_lk_id
		{
			get
			{
				return _lc_lk_id;
			}

			set
			{
				_lc_lk_id = value;
				OnPropertyChanged(nameof(lc_lk_id));
			}
		}

		/// <summary>
		/// Id rodziny
		/// </summary>
		/// <value>The lc rd identifier.</value>
		[Indexed]
		public int lc_rd_id
		{
			get
			{
				return _lc_rd_id;
			}

			set
			{
				_lc_rd_id = value;
				OnPropertyChanged(nameof(lc_rd_id));
			}
		}

		/// <summary>
		/// Zastosowana ilość
		/// </summary>
		/// <value>The lc quan.</value>
		public decimal lc_quan
		{
			get
			{
				return _lc_quan;
			}

			set
			{
				_lc_quan = value;
				OnPropertyChanged(nameof(lc_quan));
			}
		}

		/// <summary>
		/// Data rozpoczęcia leczenia
		/// </summary>
		/// <value>The lc start.</value>
		public DateTime lc_start
		{
			get
			{
				return _lc_start;
			}

			set
			{
				_lc_start = value;
				OnPropertyChanged(nameof(lc_start));
			}
		}
		/// <summary>
		/// Data zakończenia leczenia
		/// </summary>
		/// <value>The lc end.</value>
		public DateTime lc_end
		{
			get
			{
				return _lc_end;
			}

			set
			{
				_lc_end = value;
				OnPropertyChanged(nameof(lc_end));
			}
		}

		public Treatment()
		{
		}

	
	}
}
