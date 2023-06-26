using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL.DTOs.Requests;
using WebStore.DAL.DTOs.Responses;

namespace WebStore.BLL.Interfaces
{
	public interface IProductRepository
	{
		ICollection<ProductResponse> GetProducts();
		ProductResponse GetProductById(int productId);
		void DeleteProductById(int productId);
		ProductResponse CreateProduct(CreateProductRequest request);
		ProductResponse UpdateProduct(int productId, UpdateProductRequest request);
	}
}
