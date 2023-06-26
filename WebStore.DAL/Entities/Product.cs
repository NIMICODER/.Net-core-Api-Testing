using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.DAL.Entities
{

	public class Product : BaseEntity
	{
		
		public int Id { get; set; }

		[MaxLength(30)]
		public string Name { get; set; }

		public string Description { get; set; }
		public int Stock { get; set; }
		public double Price { get; set; }
	}

	public class Status
	{
		
	}
	public class BaseEntity
	{
		public BaseEntity()
		{
			CreatedAt = DateTime.Now;
			UpdateAt = DateTime.Now;
			Active = true;
		}

		public bool Active { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? UpdateAt { get; set; }
	}
}
