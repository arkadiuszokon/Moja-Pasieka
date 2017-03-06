using System;
namespace MojaPasieka.cqrs
{
	public class ApiaryToAdd : IValidator<AddApiary>
	{
		public ApiaryToAdd()
		{
		}

		public ValidationResult Validate(AddApiary command)
		{
			var vr = new ValidationResult();

			if (command.apiary.ap_name == String.Empty)
			{
				vr.result = false;
				vr.message.Add("Brak nazwy pasieki");
			}
			if (command.apiary.ap_latlng == String.Empty)
			{
				vr.result = false;
				vr.message.Add("Brak lokalizacji pasieki");
			}
			if (command.apiary.ap_datecreated == null)
			{
				vr.result = false;
				vr.message.Add("Brak daty utworzenia");
			}
			if (command.apiary.ap_datecreated > DateTime.Now)
			{
				vr.result = false;
				vr.message.Add("Data utworzenia nie może być w przyszłości");
			}
			return vr;
		}
	}
}
