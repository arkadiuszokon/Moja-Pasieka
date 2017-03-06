using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Autofac;
using MojaPasieka.cqrs;
using MojaPasieka.Utils;
using MojaPasieka.DataModel;

namespace MojaPasieka.View
{
	public class CreatorMakeBeeHivesModel : ViewModelBase, IViewModel
	{
		private ObservableCollection<FrameType> _framesTypes;
		private ObservableCollection<EnumDictionaryObject> _beeHiveTypes;
		private ObservableCollection<EnumDictionaryObject> _beeHiveMaterials;
		private ObservableCollection<EnumDictionaryObject> _beeHivesBottoms;

		public ObservableCollection<FrameType> FramesTypes
		{
			get
			{
				return _framesTypes;
			}
			set
			{
				_framesTypes = value;
				OnPropertyChanged(nameof(FramesTypes));
			}
		}

		public ObservableCollection<EnumDictionaryObject> BeeHiveTypes
		{
			get
			{
				return _beeHiveTypes;
			}
			set
			{
				_beeHiveTypes = value;
				OnPropertyChanged(nameof(BeeHiveTypes));
			}
		}

		public ObservableCollection<EnumDictionaryObject> BeeHiveMaterials
		{
			get
			{
				return _beeHiveMaterials;
			}
			set
			{
				_beeHiveMaterials = value;
				OnPropertyChanged(nameof(BeeHiveMaterials));
			}
		}

		public ObservableCollection<EnumDictionaryObject> BeeHiveBottoms
		{
			get
			{
				return _beeHivesBottoms;
			}
			set
			{
				_beeHivesBottoms = value;
				OnPropertyChanged(nameof(BeeHiveBottoms));
			}
		}

		public CreatorMakeBeeHivesModel()
		{
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				var qb = scope.Resolve<IQueryBus>();
				FramesTypes = new ObservableCollection<FrameType>(qb.Process<GetFrameTypesByMainType, List<FrameType>>(new GetFrameTypesByMainType(FrameTypeMain.REGULAR)));
				BeeHiveTypes = new ObservableCollection<EnumDictionaryObject>(EnumHelper.ReturnListFromEnum<BeeHiveType>());
				BeeHiveMaterials = new ObservableCollection<EnumDictionaryObject>(EnumHelper.ReturnListFromEnum<BeeHiveMaterialType>());
				BeeHiveBottoms = new ObservableCollection<EnumDictionaryObject>(EnumHelper.ReturnListFromEnum<BeeHiveBottomType>());
			}
		}
	}
}
