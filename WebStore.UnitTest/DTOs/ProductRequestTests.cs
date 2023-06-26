using WebStore.DAL.DTOs.Requests;

namespace WebStore.UnitTest.DTOs
{
	public class ProductRequestTests : BaseTest
	{
		[Theory]
		[InlineData("Test", "Description", 0.02, 0)]
		[InlineData("Test", null, 0.02, 1)]
		[InlineData(null, null, 0.02, 2)]
		[InlineData(null, null, -1, 3)]
		public void ValidateModel_CreateProductRequest_ReturnsCorrectNumberOfErrors(string name, string description, double price, int expectedNumberOfErrors)
		{
			var request = new CreateProductRequest 
			{ Name = name, 
				Description = description,
				Price = price
			};

			var errorList = ValidationModel(request);
			Assert.Equal(expectedNumberOfErrors, errorList.Count);
		}

		[Theory]
		[InlineData("Test", "Description", 0.02, 4, 0)]
		[InlineData("Test", null, 0.02, 9, 1)]
		[InlineData(null, null, 0.02, 1, 2)]
		[InlineData(null, null, -1, 8, 3)]
		[InlineData(null, null, -1, 200, 4)]
		public void ValidateModel_UpdateProductRequest_ReturnsCorrectNumberOfErrors(string name, string description, double price, int stock, int numberExpectedErrors)
		{
			var request = new UpdateProductRequest
			{
				Name = name,
				Description = description,
				Price = price,
				Stock = stock
			};
			var errorList = ValidationModel(request);	
			Assert.Equal(numberExpectedErrors, errorList.Count);	
		}
	}


}
