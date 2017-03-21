using System;
using Autofac;
using MojaPasieka.DataModel;
using MojaPasieka.Utils;
using Xamarin.Forms;
using Xciles.PclValueInjecter;
using MojaPasieka.cqrs;
using System.Threading.Tasks;

namespace MojaPasieka.View
{
	public class ApiaryEditableModel : Apiary, IViewModel
	{

		public Command ShowMap { get; protected set; }
		public Command Save { get; protected set; }


		public ApiaryEditableModel(ApiaryEditable view, Apiary context)
		{
			this.InjectFrom(context);
			view.Title = "Edutuj pasiekę: ''" + ap_name + "''";
			SetData();
		}

		public ApiaryEditableModel(ApiaryEditable view)
		{
			SetData();
			view.Title = "Nowa pasieka";
			ap_desc = "";
			ap_latlng = "";
			ap_datecreated = DateTime.Now;
			ap_name = "";
		}

		private void SetData()
		{
			ShowMap = new Command((obj) => 
			{ 
				using (var scope = IoC.container.BeginLifetimeScope())
				{
					IMap map = scope.Resolve<IMap>();
					map.showMapForLocation(SelectApiaryLocation);
				}
			});
			Save = new Command((obj) => 
			{
				Task.Run(async () => 
				{ 
					using (var scope = IoC.container.BeginLifetimeScope())
					{
						try
						{
							var cb = scope.Resolve<ICommandBus>();
							await cb.SendCommandAsync<SaveApiary>(new SaveApiary(this as Apiary));
							await cb.SendCommandAsync<RemoveView>(new RemoveView());
						}
						catch (ValidationException ve)
						{
							ve.MenageError();
						}
						catch (Exception ex)
						{
							ErrorUtil.handleError(ex);
						}
					}
				
				});

			});
		}

		void SelectApiaryLocation(string userLocation)
		{
			ap_latlng = userLocation;
		}
	}
}
