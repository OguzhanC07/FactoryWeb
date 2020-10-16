using AutoMapper;
using FactoryWebAPI.DTO.DTOs.ProductDtos;
using FactoryWebAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryWebAPI.WebApi.Mapping.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        { 

            CreateMap<ProductListDto, Product>();
            CreateMap<Product, ProductListDto>();
        }
    }
}
