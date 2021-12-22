using FactoryWebAPI.Client.ApiServices.Interfaces;
using FactoryWebAPI.Client.CustomFilters;
using FactoryWebAPI.Client.Extensions;
using FactoryWebAPI.Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FactoryWebAPI.Client.Areas.Member.Controllers
{
    [Area("Member")]
    [JwtAuthorize(Roles = "Member")]
    public class ProfileController : Controller
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IImageService _imageService;
        public ProfileController(IImageService imageService, IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            var user = _accessor.HttpContext.Session.GetObject<AppUserViewModel>("activeUser");
            string email = _accessor.HttpContext.Session.GetString("eMail");

            ProfileViewModel model = new ProfileViewModel
            {
                Id = user.Id,
                Email = email,
                Username = user.UserName,
                FullName = user.FullName,
            };
            return View(model);
        }
    }
}