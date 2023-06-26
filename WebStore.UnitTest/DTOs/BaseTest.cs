using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.UnitTest.DTOs
{
	public abstract class BaseTest
	{
		public IList<ValidationResult> ValidationModel(object model)
		{
			var validationResult = new List<ValidationResult>();
			var ctx = new ValidationContext(model, null, null);
			Validator.TryValidateObject(model, ctx, validationResult, true);
			return validationResult;
		}

	}


}
