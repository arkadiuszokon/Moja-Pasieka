using System;
using SQLite;

namespace MojaPasieka.DataModel
{
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
		WOODEN_INSULATED = 1,
		STYROFOAM = 2,
		STYRODUR = 3,
		WOODEN = 4,
		POLIPOLYURETHANE = 5,
		OSB = 6,
		STRAW = 7,
		INNE = 8
	}

	/// <summary>
	/// Rodzaj dennicy
	/// </summary>
	public enum BeeHiveBottomType
	{
		LOW_FULL = 1,
		LOW_WITH_NET = 2,
		HIGH_WITH_NET = 3,
		OTHER = 4
	}

	/// <summary>
	/// Rodzaj nakrycia bha od góry
	/// </summary>
	public enum BeeHiveTopType
	{
		VENTED_COVER = 1,
		BARS = 2,
		FOIL = 3,
		CLOTH = 4,
		NONE = 5
	};

	/// <summary>
	/// Typ bha, jego rodzaj/przeznaczenie
	/// </summary>
	public enum BeeHiveType
	{
		VERTICAL = 1,
		HORIZONTAL = 2,
		FOR_NUCLEUS = 3,
		FOR_SWARM = 4,
		MATING_BOX = 5
	}
}
