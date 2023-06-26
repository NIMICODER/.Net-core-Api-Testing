using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.BLL.Exceptions;
using WebStore.BLL.Implementation;
using WebStore.DAL.DTOs.Requests;
using WebStore.DAL.Mappings;

namespace WebStore.IntegrationTest.Repositories
{
	public class ProductRepositoryTests: IClassFixture<SharedDatabaseFixture>
	{
		private readonly IMapper _mapper;
		private SharedDatabaseFixture _fixture { get; }

        public ProductRepositoryTests(SharedDatabaseFixture fixture)
        {
            _fixture = fixture;
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GeneralProfile>();
            });
            
        }
        [Fact]
        public void GetProducts_ReturnsAllProducts()
        {
            using(var context = _fixture.CreateContext())
            {
                var repository = new ProductRepository(context, _mapper);
                var products = repository.GetProducts();
                Assert.Equal(10, products.Count());
            }
        }


        [Fact]
        public void GetProductsById_ProductDoesntExist_ThrowsNotFoundException()
        {
            using(var context = _fixture.CreateContext())
            {
                var repository = new ProductRepository(context, _mapper);
                var productId = 56;
                Assert.Throws<NotFoundException> (() => repository.GetProductById(productId));
                
            }
        }

		[Fact]
		public void CreateProduct_SavesCorrectData()
		{
			using (var transaction = _fixture.Connection.BeginTransaction())
			{
				var productId = 0;
				var request = new CreateProductRequest
				{
					Name = "Product 11",
					Description = "Description 11",
					Price = 5
				};
				using (var context = _fixture.CreateContext(transaction))
				{
					var repository = new ProductRepository(context, _mapper);
					var product = repository.CreateProduct(request);
					productId = product.Id;
				}
				using (var context = _fixture.CreateContext(transaction))
				{
					var repository = new ProductRepository(context, _mapper);
					var product = repository.GetProductById(productId);
					Assert.NotNull(product);
					Assert.Equal(request.Name, product.Name);
					Assert.Equal(request.Description, product.Description);
					Assert.Equal(request.Price, product.Price);
					Assert.Equal(0, product.Stock);
				}
			}
		}
		[Fact]
		public void UpdateProduct_SavesCorrectData()
		{
			using (var transaction = _fixture.Connection.BeginTransaction())
			{
				var productId = 1;
				var request = new UpdateProductRequest
				{
					Name = "Product 1",
					Description = "Description 1",
					Price = 5.12,
					Stock = 23
				};
				using (var context = _fixture.CreateContext(transaction))
				{
					var repository = new ProductRepository(context, _mapper);
					repository.UpdateProduct(productId, request);
				}
				using (var context = _fixture.CreateContext(transaction))
				{
					var repository = new ProductRepository(context, _mapper);
					var product = repository.GetProductById(productId);
					Assert.NotNull(product);
					Assert.Equal(request.Name, product.Name);
					Assert.Equal(request.Description, product.Description);
					Assert.Equal(request.Price, product.Price);
					Assert.Equal(request.Stock, product.Stock);
				}
			}
		}
		[Fact]
		public void UpdateProduct_ProductDoesntExist_ThrowsNotFoundException()
		{
			var productId = 15;
			var request = new UpdateProductRequest
			{
				Name = "Product 15",
				Description = "Description 15",
				Price = 5.12,
				Stock = 23
			};
			using (var context = _fixture.CreateContext())
			{
				var repository = new ProductRepository(context, _mapper);
				var action = () => repository.UpdateProduct(productId, request);
				Assert.Throws<NotFoundException>(action);
			}
		}
		[Fact]
		public void DeleteProductById_EnsuresProductIsDeleted()
		{
			using (var transaction = _fixture.Connection.BeginTransaction())
			{
				var productId = 2;
				using (var context = _fixture.CreateContext(transaction))
				{
					var repository = new ProductRepository(context, _mapper);
					var products = repository.GetProducts();
					repository.DeleteProductById(productId);
				}
				using (var context = _fixture.CreateContext(transaction))
				{
					var repository = new ProductRepository(context, _mapper);
					var action = () => repository.GetProductById(productId);
					Assert.Throws<NotFoundException>(action);
				}
			}
		}
		[Fact]
		public void DeleteProductById_ProductDoesntExist_ThrowsNotFoundException()
		{
			var productId = 48;
			using (var context = _fixture.CreateContext())
			{
				var repository = new ProductRepository(context, _mapper);
				var action = () => repository.DeleteProductById(productId);
				Assert.Throws<NotFoundException>(action);
			}
		}

	}
}
