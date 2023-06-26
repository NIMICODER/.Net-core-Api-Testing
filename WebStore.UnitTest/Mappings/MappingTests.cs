using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL.DTOs.Requests;
using WebStore.DAL.DTOs.Responses;
using WebStore.DAL.Entities;
using WebStore.DAL.Mappings;

namespace WebStore.UnitTest.Mappings
{
	public class MappingTests
	{
		//private readonly IConfigurationProvider _configuration;
		private readonly IConfigurationProvider _configuration;	
		private readonly IMapper _mapper;

		public MappingTests()
		{
			_configuration = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<GeneralProfile>();
			});
			_mapper = _configuration.CreateMapper();
		}

		[Fact]
		public void ShouldBeValidConfiguration()
		{
			_configuration.AssertConfigurationIsValid();	
		}

		[Theory]
		[InlineData(typeof(CreateProductRequest), typeof(Product))]	
		[InlineData(typeof(Product), typeof(ProductResponse))]
		public void Map_SourceToDestination_ExistConfiguration(Type origin, Type destination)
		{
			var instance = FormatterServices.GetUninitializedObject(origin);
			_mapper.Map(instance, origin, destination);
			
		}

	}
}
