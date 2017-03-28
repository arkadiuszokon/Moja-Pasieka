using System;
using MojaPasieka.DataModel;
using Xamarin.Forms;
using Xciles.PclValueInjecter;
using System.Collections.Generic;
using Autofac;
using MojaPasieka.cqrs;
using System.Diagnostics;
using NGraphics;
using NControl;

namespace MojaPasieka.View
{
	public class BeeHiveDetailsModel : BeeHive, IViewModel
	{

		private Xamarin.Forms.View _beeHiveDrawing;
		private List<BeeHiveBody> _beeHiveBodies;
		private string _beeHiveType;
		private string _beeHiveMaterial;
		private string _beeHiveTop;
		private string _beeHiveBottom;
		private string _beeColonyName;
		private bool _beeHiveNotEmpty = true;

		public bool BeeHiveNotEmpty
		{
			get
			{
				return _beeHiveNotEmpty;
			}
			set
			{
				_beeHiveNotEmpty = value;
				OnPropertyChanged(nameof(BeeHiveNotEmpty));
			}
		}

		public string BeeColonyName
		{
			get
			{
				return _beeColonyName;
			}
			set
			{
				_beeColonyName = value;
				OnPropertyChanged(nameof(BeeColonyName));
			}
		}

		public string BeeHiveBottom
		{
			get
			{
				return _beeHiveBottom;
			}
			set
			{
				_beeHiveBottom = value;
				OnPropertyChanged(nameof(BeeHiveBottom));
			}
		}

		public string BeeHiveTop
		{
			get
			{
				return _beeHiveTop;
			}
			set
			{
				_beeHiveTop = value;
				OnPropertyChanged(nameof(BeeHiveTop));
			}
		}

		public string BeeHiveMaterial
		{
			get
			{
				return _beeHiveMaterial;
			}
			set
			{
				_beeHiveMaterial = value;
				OnPropertyChanged(nameof(BeeHiveMaterial));
			}
		}

		public string BeeHiveType
		{
			get
			{
				return _beeHiveType;
			}
			set
			{
				_beeHiveType = value;
				OnPropertyChanged(nameof(BeeHiveType));
			}
		}

		public List<BeeHiveBody> BeeHivesBodies
		{
			get
			{
				return _beeHiveBodies;
			}
			set
			{
				_beeHiveBodies = value;
				OnPropertyChanged(nameof(BeeHivesBodies));
			}
		}

		public Xamarin.Forms.View BeeHiveDrawing
		{
			get
			{
				return _beeHiveDrawing;
			}
			set
			{
				_beeHiveDrawing = value;
				OnPropertyChanged(nameof(BeeHiveDrawing));
			}
		}

		public BeeHiveDetailsModel(BeeHive context, BeeHiveDetails view)
		{
			this.InjectFrom(context);

			using (var scope = IoC.container.BeginLifetimeScope())
			{
				BeeHiveType = EnumNameAttribute.GetValue<BeeHiveType>(this.bh_type);
				BeeHiveMaterial = EnumNameAttribute.GetValue<BeeHiveMaterialType>(this.bh_material);
				BeeHiveTop = EnumNameAttribute.GetValue<BeeHiveTopType>(this.bh_toptype);
				BeeHiveBottom = EnumNameAttribute.GetValue<BeeHiveBottomType>(this.bh_bottomtype);

				var qb = scope.Resolve<IQueryBus>();

				var colony = qb.Process<GetColonyInBeeHive, BeeColony>(new GetColonyInBeeHive(this.bh_id));
				if (colony != null)
				{
					BeeColonyName = colony.bc_name;
				}
				else
				{
					BeeHiveNotEmpty = false;
				}

				BeeHivesBodies = qb.Process<GetBeeHiveBodies, List<BeeHiveBody>>(new GetBeeHiveBodies(context.bh_id));
				var bhd = new StackLayout { Padding = 20, Orientation = StackOrientation.Vertical };
				for (int i = 0; i < BeeHivesBodies.Count; i++)
				{
					var slb = new StackLayout { Orientation = StackOrientation.Horizontal };

					bhd.Children.Add(slb);
					var frames = qb.Process<GetFramesInBeeHiveBody, List<DataModel.Frame>>(new GetFramesInBeeHiveBody(BeeHivesBodies[i].bhb_id));

					foreach (var frame in frames)
					{
						slb.Children.Add(new BoxView { 
							WidthRequest=20,
							HeightRequest=100,
							BackgroundColor= AppColors.AccentColor
						});
					}
				}
				//BeeHiveDrawing = bhd;
				var nc = new NControl.Abstractions.NControlView((NGraphics.ICanvas canvas, NGraphics.Rect rect) =>
				{
					canvas.DrawPath(new PathOp[] { new MoveTo(0, 0), new LineTo(100, 100) }, new Pen("#ff0000", 3));
				});
				nc.WidthRequest = 200;
				nc.HeightRequest = 200;
				BeeHiveDrawing = nc;

			}
		}
	}
}
