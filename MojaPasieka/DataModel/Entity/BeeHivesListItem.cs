using System;
namespace MojaPasieka.DataModel
{
	public class BeeHivesListItem : BeeHive
	{
		private int _bc_id;

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
	}
}
