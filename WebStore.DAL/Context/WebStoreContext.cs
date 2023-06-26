using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL.Entities;

namespace WebStore.DAL.Context
{
	public class WebStoreContext : DbContext
	{
        public WebStoreContext(DbContextOptions<WebStoreContext> options)
            : base(options) 
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
