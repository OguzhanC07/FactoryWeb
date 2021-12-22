using System.Threading.Tasks;
using FactoryWebAPI.Client.ApiServices.Interfaces;
using FactoryWebAPI.Client.CustomFilters;
using Microsoft.AspNetCore.Mvc;

namespace FactoryWebAPI.Client.Areas.Member.Controllers
{
    [Area("Member")]
    public class ProductController : Controller 
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService=productService;
        }

        [JwtAuthorize(Roles="Member")]
        public async Task<IActionResult> Index(){
            TempData["Active"]="products";
            return View(await _productService.GetAllProductsAsync());
        }

        [JwtAuthorize(Roles="Member")]
        public async Task<IActionResult> ProductDetail(int id){
            TempData["Active"]="products";
            return View(await _productService.GetByIdProductAsync(id));
        }
    }
}