using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebStore.BLL.Implementation;
using WebStore.BLL.Interfaces;
using WebStore.DAL.Context;

namespace WebStore.API.Extensions
{
	public static class ServiceExtensions
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddScoped<IProductRepository, ProductRepository>();

		}

		public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
		  services.AddDbContext<WebStoreContext>(opts =>
		  opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
	}
}
