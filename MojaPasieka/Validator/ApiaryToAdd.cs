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

			if (command.Apiary.ap_name == String.Empty)
			{
				vr.Result = false;
				vr.Messages.Add("Brak nazwy pasieki");
			}
			if (command.Apiary.ap_latlng == String.Empty)
			{
				vr.Result = false;
				vr.Messages.Add("Brak lokalizacji pasieki");
			}
			if (command.Apiary.ap_datecreated > DateTime.Now)
			{
				vr.Result = false;
				vr.Messages.Add("Data utworzenia nie może być w przyszłości");
			}
			return vr;
		}
	}
}
