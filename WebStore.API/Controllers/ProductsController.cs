using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.BLL.Exceptions;
using WebStore.BLL.Interfaces;
using WebStore.DAL.DTOs.Requests;
using WebStore.DAL.DTOs.Responses;

namespace WebStore.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
        private IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<ICollection<ProductResponse>> GetAllProducts()
        {
            return Ok(_productRepository.GetProducts());
        }

		[HttpGet("{id}")]
        public ActionResult GetProductById(int id)
        {
            try
            {
                var product = _productRepository.GetProductById(id);
                return Ok(product);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }


		[HttpPost]
        public ActionResult Create(CreateProductRequest request)
        {
            var product = _productRepository.CreateProduct(request);
            return Ok(product);
        }

		[HttpPut("{id}")]
        public ActionResult Update(int id, UpdateProductRequest request)
        {
            try 
            { 
            var product = _productRepository.UpdateProduct(id, request);
            return Ok(product);
			}
            catch (NotFoundException)
            {
                return NotFound();
            }

		}

		[HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _productRepository.DeleteProductById(id);
                return NoContent();

            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }



	}
}
