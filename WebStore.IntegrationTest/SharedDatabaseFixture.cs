using Bogus;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.BLL.Utility;
using WebStore.DAL.Context;
using WebStore.DAL.Entities;

namespace WebStore.IntegrationTest
{
	public class SharedDatabaseFixture : IDisposable
	{
		private static readonly object _lock = new object();
		private static bool _databaseInitialized;
		private string _dbaseName = "TestDatabase.db";

        public SharedDatabaseFixture()
        {
			Connection = new SqliteConnection($"Filename={_dbaseName}");
			Seed();
			Connection.Open();
        }

		public DbConnection Connection { get; }

		public WebStoreContext CreateContext(DbTransaction? transaction = null)
		{
			var context = new WebStoreContext(new DbContextOptionsBuilder <WebStoreContext>().UseSqlite(Connection).Options);
			if (transaction != null)
			{
				context.Database.UseTransaction(transaction);
			}
			return context;
		}

		private void Seed()
		{
			lock(_lock)
			{
				if (_databaseInitialized)
				{
					using(var context = CreateContext())
					{

						context.Database.EnsureDeleted();
						context.Database.EnsureCreated();
						SeedData(context);
					}
					_databaseInitialized = true;
				}
			}
		}

		private void SeedData(WebStoreContext context)
		{
			var productIds = 1;
			var fakeProducts = new Faker<Product>().RuleFor(o => o.Name, f => $"Product {productIds}").RuleFor(o => o.Description, f => $"Description {productIds}").RuleFor(o => o.Id, f => productIds++).RuleFor(o => o.Stock, f => f.Random.Number(1, 50)).RuleFor(o => o.Price, f => f.Random.Double(0.01, 100)).RuleFor(o => o.CreatedAt, f => DateUtility.GetCurrentDate()).RuleFor(o => o.UpdateAt, f => DateUtility.GetCurrentDate());
			var products = fakeProducts.Generate(10);
			context.AddRange(products);
			context.SaveChanges();
		}




        public void Dispose() =>
			Connection.Dispose();
	}
}
