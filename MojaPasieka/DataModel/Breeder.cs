using System;
using SQLite;
namespace MojaPasieka.DataModel
{
	/// <summary>
	/// Hodowca
	/// </summary>
	[Table("tb_breeder")]
	public class Breeder : DataModelBase, IDataModel
	{
		
		
		private int _br_id;
		private string _br_name;
		private string _br_phone;
		private string _br_email;
		private string _br_address;
		private string _br_desc;
		private DateTime _br_timestamp;

		/// <summary>
		/// Id hodowcy
		/// </summary>
		/// <value>The br identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int br_id
		{
			get
			{
				return _br_id;
			}

			set
			{
				_br_id = value;
				OnPropertyChanged(nameof(br_id));
			}
		}

		/// <summary>
		/// Nazwa hodowcy
		/// </summary>
		/// <value>The name of the br.</value>
		public string br_name
		{
			get
			{
				return _br_name;
			}

			set
			{
				_br_name = value;
				OnPropertyChanged(nameof(br_name));
			}
		}

		/// <summary>
		/// Telefon howodcy
		/// </summary>
		/// <value>The br phone.</value>
		public string br_phone
		{
			get
			{
				return _br_phone;
			}

			set
			{
				_br_phone = value;
				OnPropertyChanged(nameof(br_phone));
			}
		}

		/// <summary>
		/// Email hodowcy
		/// </summary>
		/// <value>The br email.</value>
		public string br_email
		{
			get
			{
				return _br_email;
			}

			set
			{
				_br_email = value;
				OnPropertyChanged(nameof(br_email));
			}
		}

		/// <summary>
		/// Adres hodowcy
		/// </summary>
		/// <value>The br address.</value>
		public string br_address
		{
			get
			{
				return _br_address;
			}

			set
			{
				_br_address = value;
				OnPropertyChanged(nameof(br_address));
			}
		}

		/// <summary>
		/// Dodatkowy opis
		/// </summary>
		/// <value>The br desc.</value>
		public string br_desc
		{
			get
			{
				return _br_desc;
			}

			set
			{
				_br_desc = value;
				OnPropertyChanged(nameof(br_desc));
			}
		}

		public DateTime br_timestamp
		{
			get
			{
				return _br_timestamp;
			}

			set
			{
				_br_timestamp = value;
			}
		}
	}
}
