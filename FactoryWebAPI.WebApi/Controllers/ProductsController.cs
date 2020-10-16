using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FactoryWebAPI.Business.Interfaces;
using FactoryWebAPI.DTO.DTOs.ProductDtos;
using FactoryWebAPI.Entities.Concrete;
using FactoryWebAPI.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FactoryWebAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper, IProductService productService)
        {
            _productService = productService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<ProductListDto>>(await _productService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(IFormFile file, int id)
        {


            return Ok(_mapper.Map<ProductListDto>(await _productService.FindByIdAsync(id)));
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromForm] ProductAddModel model)
        {

            var uploadModel = await UploadFileAsync(model.Image, "image/jpeg");
            if (uploadModel.UploadState == Enums.UploadState.Success)
            {
                model.ImagePath = uploadModel.NewName;
                await _productService.AddAsync(_mapper.Map<Product>(model));
                return Created("", model);
            }
            else if (uploadModel.UploadState ==Enums.UploadState.NotExist)
            {
                model.ImagePath = "default.jpg";
                return Created("", model);
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update([FromForm] ProductUpdateModel model)
        //{

        //}
    }
}
