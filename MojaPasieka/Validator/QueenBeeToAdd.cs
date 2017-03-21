using System;
using System.Threading.Tasks;
using Autofac;
using MojaPasieka.DataModel;

namespace MojaPasieka.cqrs
{
	public class QueenBeeToAdd : IValidator<SaveQueenBee>
	{
		private ILifetimeScope scope;

		public QueenBeeToAdd(ILifetimeScope scope )
		{
			this.scope = scope;
		}

		public ValidationResult Validate(SaveQueenBee command)
		{
			var vr = new ValidationResult();
			if (command.Queen.qb_bb_id == 0)
			{
				vr.Result = false;
				vr.Messages.Add("Nie możesz dodać matki do ula, który nie istnieje");
			}
			if (command.Queen.qb_year < 2010)
			{
				vr.Result = false;
				vr.Messages.Add("Nie możesz dodać tak starej matki");
			}
			if (!scope.Resolve<IQueryBus>().Process<CheckExists, bool>(new CheckExists(typeof(BeeColony), command.Queen.qb_bc_id)))
			{
				vr.Result = false;
				vr.Messages.Add("Rodzina do której dodajesz matkę nie istnieje");
			}
			return vr;
		}
	}
}
