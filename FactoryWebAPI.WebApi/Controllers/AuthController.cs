using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FactoryWebAPI.Business.Interfaces;
using FactoryWebAPI.Business.StringInfo.cs;
using FactoryWebAPI.DTO.DTOs.AppUserDtos;
using FactoryWebAPI.Entities.Concrete;
using FactoryWebAPI.WebApi.CustomFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FactoryWebAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        public AuthController(IJwtService jwtService, IMapper mapper, IAppUserService appUserService)
        {
            _appUserService = appUserService;
            _mapper = mapper;
            _jwtService = jwtService;
        }


        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
            var user = await _appUserService.FindByEmailorUserName(appUserLoginDto.Email);
            if (user != null)
            {
                appUserLoginDto.Password = _appUserService.CreateHashPassword(appUserLoginDto.Password);
                if (await _appUserService.CheckHashPassword(appUserLoginDto))
                {
                    var roles = await _appUserService.GetRolesByEmail(appUserLoginDto.Email);
                    var token = _jwtService.GenerateJwt(user, roles);

                    return Created("", token);
                }
                else
                    return BadRequest("Kullanıcı adı veya şifre hatalıdır.");
            }
            return BadRequest("Kullanıcı adı veya şifre hatalıdır.");
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp(AppUserAddDto appUserAddDto, [FromServices] IAppUserRoleService appUserRoleService, [FromServices] IAppRoleService appRoleService)
        {
            var appUser = await _appUserService.FindByEmailorUserName(appUserAddDto.Email);
            if (appUser != null)
            {
                return BadRequest($"{appUserAddDto.Email} veya {appUserAddDto.UserName} alınmıştır. Başka e-posta adresi veya kullanıcı adı deneyiniz.");
            }

            appUserAddDto.Password = _appUserService.CreateHashPassword(appUserAddDto.Password);
            await _appUserService.AddAsync(_mapper.Map<AppUser>(appUserAddDto));

            var user = await _appUserService.FindByEmailorUserName(appUserAddDto.UserName);
            var role = await appRoleService.FindByNameAsync(RoleInfo.Member);

            await appUserRoleService.AddAsync(new AppUserRole
            {
                AppRoleId = role.Id,
                AppUserId = user.Id
            });

            return Created("", appUserAddDto);
        }


    }
}
