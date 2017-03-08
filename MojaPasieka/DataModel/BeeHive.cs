using System;
using SQLite;

namespace MojaPasieka.DataModel
{
	/// <summary>
	/// Ul
	/// </summary>
	[Table("tb_beehive")]
	public class BeeHive : DataModelBase, IDataModel
	{



		private int _bh_id;

		/// <summary>
		/// ID bha
		/// </summary>
		/// <value>The bh identifier.</value>
		[PrimaryKey, AutoIncrement]
		public int bh_id {
			get {
				return _bh_id;
			}

			set {
				_bh_id = value;
				OnPropertyChanged (nameof (bh_id));
			}
		}

		private string _bh_name;

		/// <summary>
		/// nazwa własna / numer pasieki
		/// </summary>
		/// <value>The name of the bh.</value>
		public string bh_name {
			get {
				return _bh_name;
			}

			set {
				_bh_name = value;
				OnPropertyChanged (nameof (bh_name));
			}
		}

		private int _bh_ap_id;

		/// <summary>
		/// id pasieki
		/// </summary>
		/// <value>The bh ps identifier.</value>
		[Indexed]
		public int bh_ap_id {
			get {
				return _bh_ap_id;
			}

			set {
				_bh_ap_id = value;
				OnPropertyChanged (nameof (bh_ap_id));
			}
		}
		private BeeHiveTopType _bh_toptype;

		public BeeHiveTopType bh_toptype {
			get {
				return _bh_toptype;
			}

			set {
				_bh_toptype = value;
				OnPropertyChanged (nameof (bh_toptype));
			}
		}

		private BeeHiveBottomType _bh_bottomtype;

		public BeeHiveBottomType bh_bottomtype {
			get {
				return _bh_bottomtype;
			}

			set {
				_bh_bottomtype = value;
				OnPropertyChanged (nameof (bh_bottomtype));
			}
		}

		private BeeHiveType _bh_type;

		public BeeHiveType bh_type {
			get {
				return _bh_type;
			}

			set {
				_bh_type = value;
				OnPropertyChanged (nameof (bh_type));
			}
		}

		private string _bh_paint;

		/// <summary>
		/// Malowanie bha
		/// </summary>
		/// <value>The bh paint.</value>
		public string bh_paint {
			get {
				return _bh_paint;
			}

			set {
				_bh_paint = value;
				OnPropertyChanged (nameof (bh_paint));
			}
		}

		private BeeHiveMaterialType _bh_material;

		public BeeHiveMaterialType bh_material {
			get {
				return _bh_material;
			}

			set {
				_bh_material = value;
				OnPropertyChanged (nameof (bh_material));
			}
		}

		private string _bh_desc;

		/// <summary>
		/// Dodatkowy opis bha
		/// </summary>
		/// <value>The bh desc.</value>
		public string bh_desc {
			get {
				return _bh_desc;
			}

			set {
				_bh_desc = value;
				OnPropertyChanged (nameof (bh_desc));
			}
		}

		private DateTime _bh_timestamp;

		/// <summary>
		/// Timestamp z dodania do bazy
		/// </summary>
		/// <value>The bh timestamp.</value>
		public DateTime bh_timestamp {
			get {
				return _bh_timestamp;
			}

			set {
				_bh_timestamp = value;
				OnPropertyChanged (nameof (bh_timestamp));
			}
		}


	}

	/// <summary>
	/// Rodzaj materiału z którego wykonany jest bh
	/// </summary>
	public enum BeeHiveMaterialType
	{
		[EnumName("Drewniany ocieplony")]
		WOODEN_INSULATED = 1,

		[EnumName("Styropian")]
		STYROFOAM = 2,

		[EnumName("Styrodur")]
		STYRODUR = 3,

		[EnumName("Drewniany jednościenny")]
		WOODEN = 4,

		[EnumName("Poliuretan")]
		POLYURETHANE = 5,

		[EnumName("OSB")]
		OSB = 6,

		[EnumName("Słoma")]
		STRAW = 7,

		[EnumName("Inne")]
		INNE = 8
	}

	/// <summary>
	/// Rodzaj dennicy
	/// </summary>
	public enum BeeHiveBottomType
	{
		[EnumName("Niska pełna")]
		LOW_FULL = 1,

		[EnumName("Niska osiatkowana")]
		LOW_WITH_NET = 2,

		[EnumName("Wysoka osiatkowana")]
		HIGH_WITH_NET = 3,

		[EnumName("Inna")]
		OTHER = 4
	}

	/// <summary>
	/// Rodzaj nakrycia ula od góry
	/// </summary>
	public enum BeeHiveTopType
	{
		[EnumName("Powałka")]
		VENTED_COVER = 1,

		[EnumName("Beleczki")]
		BARS = 2,

		[EnumName("Folia")]
		FOIL = 3,

		[EnumName("Płótno")]
		CLOTH = 4,

		[EnumName("Brak")]
		NONE = 5
	};

	/// <summary>
	/// Typ ula, jego rodzaj/przeznaczenie
	/// </summary>
	public enum BeeHiveType
	{
		[EnumName("Stojak")]
		VERTICAL = 1,

		[EnumName("Leżak")]
		HORIZONTAL = 2,

		[EnumName("Odkładowy")]
		FOR_NUCLEUS = 3,

		[EnumName("Rojnica")]
		FOR_SWARM = 4,

		[EnumName("Weselny")]
		MATING_BOX = 5
	}
}
