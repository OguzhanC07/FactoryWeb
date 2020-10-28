﻿using AutoMapper;
using FactoryWebAPI.DTO.DTOs.AppUserDtos;
using FactoryWebAPI.DTO.DTOs.ProductDtos;
using FactoryWebAPI.Entities.Concrete;
using FactoryWebAPI.WebApi.Models;
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
            #region Product
            CreateMap<ProductListDto, Product>();
            CreateMap<Product, ProductListDto>();

            CreateMap<Product, ProductAddModel>();
            CreateMap<ProductAddModel, Product>();

            CreateMap<Product, ProductUpdateModel>();
            CreateMap<ProductUpdateModel, Product>();
            #endregion


            #region AppUser
            CreateMap<AppUserLoginDto, AppUser>();
            CreateMap<AppUser, AppUserLoginDto>();

            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>(); 
            #endregion
        }
    }
}
