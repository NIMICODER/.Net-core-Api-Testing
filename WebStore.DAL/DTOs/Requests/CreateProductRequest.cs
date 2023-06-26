using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.DAL.DTOs.Requests
{
	public class CreateProductRequest
	{
		[Required]
		[StringLength(30, MinimumLength = 3)]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		[Range(0.01, 1000)]
		public double Price { get; set; }
	}

	public class UpdateProductRequest : CreateProductRequest
	{
		[Required]
		[Range(0, 100)]
		public int Stock { get; set; }
	}
}
