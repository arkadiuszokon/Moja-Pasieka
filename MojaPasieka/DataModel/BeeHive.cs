using System;
using SQLite;
using SQLite.Net.Attributes;
namespace MojaPasieka.DataModel
{
	public class BeeHive : DataModelBase
	{
		private int _ul_id;

		/// <summary>
		/// ID ula
		/// </summary>
		/// <value>The ul identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int ul_id {
			get {
				return _ul_id;
			}

			set {
				_ul_id = value;
				OnPropertyChanged (nameof (ul_id));
			}
		}

		private string _ul_name;

		/// <summary>
		/// nazwa własna / numer pasieki
		/// </summary>
		/// <value>The name of the ul.</value>
		public string ul_name {
			get {
				return _ul_name;
			}

			set {
				_ul_name = value;
				OnPropertyChanged (nameof (ul_name));
			}
		}

		private int _ul_ps_id;

		/// <summary>
		/// id pasieki
		/// </summary>
		/// <value>The ul ps identifier.</value>
		public int ul_ps_id {
			get {
				return _ul_ps_id;
			}

			set {
				_ul_ps_id = value;
				OnPropertyChanged (nameof (ul_ps_id));
			}
		}
		private BeeHiveTopType _ul_toptype;

		public BeeHiveTopType ul_toptype {
			get {
				return _ul_toptype;
			}

			set {
				_ul_toptype = value;
				OnPropertyChanged (nameof (ul_toptype));
			}
		}

		private BeeHiveBottomType _ul_bottomtype;

		public BeeHiveBottomType ul_bottomtype {
			get {
				return _ul_bottomtype;
			}

			set {
				_ul_bottomtype = value;
				OnPropertyChanged (nameof (ul_bottomtype));
			}
		}

		private BeeHiveType _ul_type;

		public BeeHiveType ul_type {
			get {
				return _ul_type;
			}

			set {
				_ul_type = value;
				OnPropertyChanged (nameof (ul_type));
			}
		}

		private string _ul_paint;

		/// <summary>
		/// Malowanie ula
		/// </summary>
		/// <value>The ul paint.</value>
		public string ul_paint {
			get {
				return _ul_paint;
			}

			set {
				_ul_paint = value;
				OnPropertyChanged (nameof (ul_paint));
			}
		}

		private BeeHiveMaterialType _ul_material;

		public BeeHiveMaterialType ul_material {
			get {
				return _ul_material;
			}

			set {
				_ul_material = value;
				OnPropertyChanged (nameof (ul_material));
			}
		}

		private string _ul_desc;

		/// <summary>
		/// Dodatkowy opis ula
		/// </summary>
		/// <value>The ul desc.</value>
		public string ul_desc {
			get {
				return _ul_desc;
			}

			set {
				_ul_desc = value;
				OnPropertyChanged (nameof (ul_desc));
			}
		}

		private DateTime _ul_timestamp;

		/// <summary>
		/// Timestamp z dodania do bazy
		/// </summary>
		/// <value>The ul timestamp.</value>
		public DateTime ul_timestamp {
			get {
				return _ul_timestamp;
			}

			set {
				_ul_timestamp = value;
				OnPropertyChanged (nameof (ul_timestamp));
			}
		}
	}

	/// <summary>
	/// Rodzaj materiału z którego wykonany jest ul
	/// </summary>
	public enum BeeHiveMaterialType
	{

		DREWNIANY_OCIEPLNY = 1,
		STYROPIAN = 2,
		STYRODUR = 3,
		DREWNIANY_JEDNOSCIENNY = 4,
		POLIURETAN = 5,
		OSB = 6,
		SLOMA = 7,
		INNE = 8
	}

	/// <summary>
	/// Rodzaj dennicy
	/// </summary>
	public enum BeeHiveBottomType
	{
		NISKA_PELNA = 1,
		NISKA_OSIATKOWANA = 2,
		WYSOKA_OSIATKOWANA = 3,
		INNA = 4

	}

	/// <summary>
	/// Rodzaj nakrycia ula od góry
	/// </summary>
	public enum BeeHiveTopType
	{
		POWALKA = 1,
		BELECZKI = 2,
		FOLIA = 3,
		PLOTNO = 4,
		BRAK = 5
	};

	/// <summary>
	/// Typ ula, jego rodzaj/przeznaczenie
	/// </summary>
	public enum BeeHiveType
	{
		STOJAK = 1,
		LEZAK = 2,
		ODKLADOWY = 3,
		ROJNICA = 4,
		WESELNY = 5
	}
}
