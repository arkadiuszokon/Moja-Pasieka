using System;
using SQLite;
namespace MojaPasieka.DataModel
{
	/// <summary>
	/// Odczyt wagi
	/// </summary>
	[Table("tb_scalevalue")]
	public class ScaleValue : DataModelBase, IDataModel
	{
		
		private int _sv_id;
		private int _sv_bc_id;
		private int _sv_sc_id;
		private decimal _sv_value;
		private string _sv_desc;
		private DateTime _sv_date;
		private DateTime _sv_timestamp;

		/// <summary>
		/// Id odczytu wagi
		/// </summary>
		/// <value>The sv identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int sv_id
		{
			get
			{
				return _sv_id;
			}

			set
			{
				_sv_id = value;
				OnPropertyChanged(nameof(sv_id));
			}
		}

		/// <summary>
		/// Id rodziny
		/// </summary>
		/// <value>The sv bc identifier.</value>
		[Indexed]
		public int sv_bc_id
		{
			get
			{
				return _sv_bc_id;
			}

			set
			{
				_sv_bc_id = value;
				OnPropertyChanged(nameof(sv_bc_id));
			}
		}

		/// <summary>
		/// Id wagi
		/// </summary>
		/// <value>The sv sc identifier.</value>
		[Indexed]
		public int sv_sc_id
		{
			get
			{
				return _sv_sc_id;
			}

			set
			{
				_sv_sc_id = value;
				OnPropertyChanged(nameof(sv_sc_id));
			}
		}

		/// <summary>
		/// Odczyt wagi
		/// </summary>
		/// <value>The sv value.</value>
		public decimal sv_value
		{
			get
			{
				return _sv_value;
			}

			set
			{
				_sv_value = value;
				OnPropertyChanged(nameof(sv_value));
			}
		}

		/// <summary>
		/// Dodatkowy opis
		/// </summary>
		/// <value>The sv desc.</value>
		public string sv_desc
		{
			get
			{
				return _sv_desc;
			}

			set
			{
				_sv_desc = value;
				OnPropertyChanged(nameof(sv_desc));
			}
		}

		/// <summary>
		/// Data odczytu
		/// </summary>
		/// <value>The sv date.</value>
		public DateTime sv_date
		{
			get
			{
				return _sv_date;
			}

			set
			{
				_sv_date = value;
				OnPropertyChanged(nameof(sv_date));
			}
		}

		public DateTime sv_timestamp
		{
			get
			{
				return _sv_timestamp;
			}

			set
			{
				_sv_timestamp = value;
				OnPropertyChanged(nameof(sv_timestamp));
			}
		}
	}
}
