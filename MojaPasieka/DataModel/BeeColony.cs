using System;
using SQLite;

namespace MojaPasieka.DataModel
{
	[Table("tb_beecolony")]
	public class BeeColony : DataModelBase, IDataModel
	{
		

		private int _bc_id;
		private DateTime _bc_created;
		private string _bc_name;
		private BeeColonyInspectedType _bc_inspectedtype;
		private string _bc_desc;
		private DateTime _bc_timestamp;

		/// <summary>
		/// Id rodziny
		/// </summary>
		/// <value>The bc identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int bc_id
		{
			get
			{
				return _bc_id;
			}

			set
			{
				_bc_id = value;
				OnPropertyChanged(nameof(bc_id));
			}
		}

		/// <summary>
		/// Data utworzenia
		/// </summary>
		/// <value>The bc created.</value>
		public DateTime bc_created
		{
			get
			{
				return _bc_created;
			}

			set
			{
				_bc_created = value;
				OnPropertyChanged(nameof(bc_created));
			}
		}

		/// <summary>
		/// Nazwa/ dodatkowe oznaczenie rodziny
		/// </summary>
		/// <value>The name of the bc.</value>
		public string bc_name
		{
			get
			{
				return _bc_name;
			}

			set
			{
				_bc_name = value;
				OnPropertyChanged(nameof(bc_name));
			}
		}

		/// <summary>
		/// Rodzaj zapisów z przeględu rodzin
		/// </summary>
		/// <value>The bc inspectedtype.</value>
		public BeeColonyInspectedType bc_inspectedtype
		{
			get
			{
				return _bc_inspectedtype;
			}

			set
			{
				_bc_inspectedtype = value;
				OnPropertyChanged(nameof(bc_inspectedtype));
			}
		}

		/// <summary>
		/// Dodatkowy opis
		/// </summary>
		/// <value>The bc desc.</value>
		public string bc_desc
		{
			get
			{
				return _bc_desc;
			}

			set
			{
				_bc_desc = value;
				OnPropertyChanged(nameof(bc_desc));
			}
		}

		public DateTime bc_timestamp
		{
			get
			{
				return _bc_timestamp;
			}

			set
			{
				_bc_timestamp = value;
				OnPropertyChanged(nameof(bc_timestamp));
			}
		}
	}

	/// <summary>
	/// Rodzaj przeprowadzanego przeglądu
	/// </summary>
	public enum BeeColonyInspectedType
	{
		SIMPLIFIED = 1,
		DETAILED = 2
	}
}
