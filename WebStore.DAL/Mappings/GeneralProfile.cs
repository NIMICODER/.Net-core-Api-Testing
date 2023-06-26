using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL.DTOs.Requests;
using WebStore.DAL.DTOs.Responses;
using WebStore.DAL.Entities;

namespace WebStore.DAL.Mappings
{
	public class GeneralProfile : Profile
	{
        public GeneralProfile()
        {
            CreateMap<CreateProductRequest, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()
                )
                .ForMember(dest => dest.Stock, opt => opt.Ignore()
                )
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()
                )
                .ForMember(dest => dest.UpdateAt, opt => opt.Ignore()
                )
                .ForMember(dest => dest.Active, opt => opt.Ignore()
                );
            CreateMap<Product, ProductResponse>();
            
        }
    }
}
