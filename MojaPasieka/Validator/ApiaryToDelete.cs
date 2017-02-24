using System;
using System.Threading.Tasks;

namespace MojaPasieka.cqrs
{
	public class ApiaryToDelete : IValidator<DeleteApiary>
	{
		public ApiaryToDelete()
		{
		}

		public ValidationResult Validate(DeleteApiary command)
		{
			var vr = new ValidationResult();
			vr.result = true;
			return vr;
		}
	}
}
