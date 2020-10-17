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
        public FilesController(IProductService productService)
        {
            _productService = productService;
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
                return File($"/img/{product.ImagePath}", "image/jpeg");
            }
        }
    }
}
