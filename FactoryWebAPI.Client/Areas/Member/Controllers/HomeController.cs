using FactoryWebAPI.Client.CustomFilters;
using Microsoft.AspNetCore.Mvc;

namespace FactoryWebAPI.Client.Areas.Member.Controllers
{
    [Area("Member")]
    [JwtAuthorize(Roles="Member")]
    public class HomeController : Controller
    {
        public IActionResult Index(){
            TempData["Active"] = "home";
            return View();
        }
    }    
}