using System;
using SQLite;
namespace MojaPasieka.DataModel
{
	/// <summary>
	/// Leczenie
	/// </summary>
	[Table("tb_treatment")]
	public class Treatment : DataModelBase, IDataModel
	{
		
		private int _tt_id;
		private int _tt_md_id;
		private int _tt_bc_id;
		private decimal _tt_quan;
		private DateTime _tt_start;
		private DateTime _tt_end;
		private string _tt_effect;
		private string _tt_desc;

		/// <summary>
		/// id leczenia
		/// </summary>
		/// <value>The tt identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int tt_id
		{
			get
			{
				return _tt_id;
			}

			set
			{
				_tt_id = value;
				OnPropertyChanged(nameof(tt_id));
			}
		}

		/// <summary>
		/// id zastosowanego leku
		/// </summary>
		/// <value>The tt lk identifier.</value>
		[Indexed]
		public int tt_md_id
		{
			get
			{
				return _tt_md_id;
			}

			set
			{
				_tt_md_id = value;
				OnPropertyChanged(nameof(tt_md_id));
			}
		}

		/// <summary>
		/// Id rodziny
		/// </summary>
		/// <value>The tt bc identifier.</value>
		[Indexed]
		public int tt_bc_id
		{
			get
			{
				return _tt_bc_id;
			}

			set
			{
				_tt_bc_id = value;
				OnPropertyChanged(nameof(tt_bc_id));
			}
		}

		/// <summary>
		/// Zastosowana ilość
		/// </summary>
		/// <value>The tt quan.</value>
		public decimal tt_quan
		{
			get
			{
				return _tt_quan;
			}

			set
			{
				_tt_quan = value;
				OnPropertyChanged(nameof(tt_quan));
			}
		}

		/// <summary>
		/// Data rozpoczęcia leczenia
		/// </summary>
		/// <value>The tt start.</value>
		public DateTime tt_start
		{
			get
			{
				return _tt_start;
			}

			set
			{
				_tt_start = value;
				OnPropertyChanged(nameof(tt_start));
			}
		}
		/// <summary>
		/// Data zakończenia leczenia
		/// </summary>
		/// <value>The tt end.</value>
		public DateTime tt_end
		{
			get
			{
				return _tt_end;
			}

			set
			{
				_tt_end = value;
				OnPropertyChanged(nameof(tt_end));
			}
		}

		/// <summary>
		/// Opis efektu leczenia
		/// </summary>
		/// <value>The tt effect.</value>
		public string tt_effect
		{
			get
			{
				return _tt_effect;
			}

			set
			{
				_tt_effect = value;
				OnPropertyChanged(nameof(tt_effect));
			}
		}

		/// <summary>
		/// Dodatkowy opis
		/// </summary>
		/// <value>The tt desc.</value>
		public string tt_desc
		{
			get
			{
				return _tt_desc;
			}

			set
			{
				_tt_desc = value;
				OnPropertyChanged(nameof(tt_desc));
			}
		}

	
	}
}
