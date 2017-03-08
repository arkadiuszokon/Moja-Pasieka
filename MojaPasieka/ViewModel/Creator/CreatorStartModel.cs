using System;
using System.Windows.Input;
using Xamarin.Forms;
using Autofac;
using System.Diagnostics;

namespace MojaPasieka.View
{
	public class CreatorStartModel : ViewModelBase, IViewModel
	{

		public Command nextStep { get; protected set; }

		private bool _isNextStepVisible = true;

		public bool IsNextStepVisible {
		
			get
			{
				return _isNextStepVisible;
			}
			set
			{
				_isNextStepVisible = value;
				OnPropertyChanged(nameof(IsNextStepVisible));
			}
		}

		public CreatorStartModel(CreatorStart view)
		{
			nextStep = new Command(showNextStep);

		}

		private void showNextStep(object obj)
		{
			using (var scope = IoC.container.BeginLifetimeScope())
			{
				var creator = scope.Resolve<Creator>();
				creator.nextStep();
				IsNextStepVisible = false;
			}
		}

	}
}
