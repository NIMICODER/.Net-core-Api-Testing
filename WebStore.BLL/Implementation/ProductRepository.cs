using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.BLL.Exceptions;
using WebStore.BLL.Interfaces;
using WebStore.DAL.Context;
using WebStore.DAL.DTOs.Requests;
using WebStore.DAL.DTOs.Responses;
using WebStore.DAL.Entities;

namespace WebStore.BLL.Implementation
{
	public class ProductRepository : IProductRepository
	{
		private readonly WebStoreContext _storeContext;
		private readonly IMapper _mapper;

        public ProductRepository(WebStoreContext storeContext, IMapper mapper)
        {
			_storeContext = storeContext;
			_mapper = mapper;
        }

        public ProductResponse CreateProduct(CreateProductRequest request)
		{
			var product = _mapper.Map<Product>(request);
			product.Stock = 0;
			_storeContext.Products.Add(product);
			_storeContext.SaveChanges();

			return _mapper.Map<ProductResponse>(product);
		}

		public void DeleteProductById(int productId)
		{
			var product = _storeContext.Products.Find(productId);
			if (product != null)
			{
				_storeContext.Products.Remove(product);
				_storeContext.SaveChanges();
			}
			else
			{
				throw new NotFoundException();
			}
		}

		public ProductResponse GetProductById(int productId)
		{
			var product = _storeContext.Products.Find(productId);
			if (product != null)
				return _mapper.Map<ProductResponse>(product);

				throw new NotFoundException();
		}

		public ICollection<ProductResponse> GetProducts()
		{
			return _storeContext.Products.Select(p => _mapper.Map<ProductResponse>(p)).ToList();	
		}

		public ProductResponse UpdateProduct(int productId, UpdateProductRequest request)
		{
			var product = _storeContext.Products.Find(productId);
			if (product != null)
			{
				product.Name = request.Name;
				product.Description = request.Description;
				product.Price = request.Price;
				product.Stock = request.Stock;

				_storeContext.Products.Update(product);
				_storeContext.SaveChanges();

				return _mapper.Map<ProductResponse>(product);
			}

			throw new NotFoundException();
		}
	}
}
