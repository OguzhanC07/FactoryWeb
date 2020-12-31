using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FactoryWebAPI.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FactoryWebAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IAppUserService _appUserService;
        public FilesController(IProductService productService, IAppUserService appUserService)
        {
            _productService = productService;
            _appUserService = appUserService;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetImageByProductId(int id)
        {
            var product = await _productService.FindByIdAsync(id);
            if (string.IsNullOrWhiteSpace(product.ImagePath))
            {
                return NotFound();
            }
            else
            {
                string type = "image/jpeg";
                if (product.ImagePath.Contains(".png"))
                {
                    type = "image/png";
                }
                return File($"/img/{product.ImagePath}", type);
            }
        }
        
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetProfileImage(int id)
        {
            var user =await _appUserService.FindByIdAsync(id);

            if (string.IsNullOrWhiteSpace(user.ImagePath))
            {
                return NotFound();
            }
            else
            {
                string type = "image/jpeg";
                if (user.ImagePath.Contains(".png"))
                {
                    type = "image/png";
                }
                return File($"/profile/{user.ImagePath}", type);
            }
        }
    }
}
