﻿using FactoryWebAPI.Business.Concrete;
using FactoryWebAPI.Business.Interfaces;
using FactoryWebAPI.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using FactoryWebAPI.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.Business.Containers.MicrosoftIoC
{
    public static class CustomIocExtension
    {
        public static void AddDependicies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IAppRoleDal, EfAppRoleRepository>();
            services.AddScoped<IAppRoleService, AppRoleManager>();

            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<IAppUserRoleDal,EfAppUserRoleRepository>();
            services.AddScoped<IAppUserRoleService,AppUserRoleManager>();

            services.AddScoped<IDealerDal, EfDealerRepository>();
            services.AddScoped<IDealerService, DealerManager>();

            services.AddScoped<IOrderDetailDal, EfOrderDetailRepository>();
            services.AddScoped<IOrderDetailService, OrderDetailManager>();

            services.AddScoped<IProductDal, EfProductRepository>();
            services.AddScoped<IProductService, ProductManager>();



        }
    }
}