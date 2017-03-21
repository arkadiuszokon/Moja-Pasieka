using System;
using MojaPasieka.DataModel;
using Xamarin.Forms;
using Xciles.PclValueInjecter;
using System.Collections.Generic;
using Autofac;
using MojaPasieka.cqrs;

namespace MojaPasieka.View
{
	public class BeeHiveDetailsModel : BeeHive, IViewModel
	{

		private StackLayout _beeHiveDrawing;
		private List<BeeHiveBody> _beeHiveBodies;

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

		public StackLayout BeeHiveDrawing
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
				var qb = scope.Resolve<IQueryBus>();
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
							BackgroundColor= AppColors.AccentColor,

						});
					}
				}
				BeeHiveDrawing = bhd;
			}
		}
	}
}
