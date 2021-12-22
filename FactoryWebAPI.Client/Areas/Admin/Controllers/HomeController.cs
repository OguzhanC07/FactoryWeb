using FactoryWebAPI.Client.CustomFilters;
using Microsoft.AspNetCore.Mvc;

namespace FactoryWebAPI.Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    [JwtAuthorize(Roles="Admin")]
    public class HomeController : Controller{
        public IActionResult Index(){
            return View();
        }
    }
    
}