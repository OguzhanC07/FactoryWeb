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
        private readonly IMailService _mailService;

        public ProductsController(IMapper mapper,IMailService mailService, IProductService productService)
        {
            _productService = productService;
            _mapper = mapper;
            _mailService = mailService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {            
            return Ok(_mapper.Map<List<ProductListDto>>(await _productService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
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
            else if (uploadModel.UploadState == Enums.UploadState.NotExist)
            {
                model.ImagePath = "default.jpg";
                return Created("", model);
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] ProductUpdateModel model)
        {

            if (id != model.Id)
                return BadRequest("Yanlış değer girildi");

            var uploadModel = await UploadFileAsync(model.Image, "image/jpeg");

            if (uploadModel.UploadState == Enums.UploadState.Success)
            {
                var updatedProduct = await _productService.FindByIdAsync(id);
                updatedProduct.Name = model.Name;
                updatedProduct.Description = model.Description;
                updatedProduct.ImagePath = uploadModel.NewName;

                await _productService.UpdateAsync(updatedProduct);
                return NoContent();
            }
            else if (uploadModel.UploadState == Enums.UploadState.NotExist)
            {
                var updatedProduct = await _productService.FindByIdAsync(id);
                updatedProduct.Name = model.Name;
                updatedProduct.Description = model.Description;

                await _productService.UpdateAsync(updatedProduct);
                return NoContent();
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deletedProduct =await _productService.FindByIdAsync(id);
            if (deletedProduct!=null)
            {
                deletedProduct.IsVisible = false;
                await _productService.UpdateAsync(deletedProduct);
                return NoContent();
            }
            else
            {
                return NotFound("Girilen Id'ye ait ürün yoktur.");
            }
        }

    }
}
