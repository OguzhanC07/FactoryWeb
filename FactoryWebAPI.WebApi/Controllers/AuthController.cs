using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FactoryWebAPI.Business.Interfaces;
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
        public AuthController(IMapper mapper, IAppUserService appUserService)
        {
            _appUserService = appUserService;
            _mapper = mapper;
        }


        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
            var user = await _appUserService.FindByEmailandUserName(appUserLoginDto.Email, "");
            if (user != null)
            {
                appUserLoginDto.Password = _appUserService.CreateHashPassword(appUserLoginDto.Password);
                if (await _appUserService.CheckHashPassword(appUserLoginDto))
                {
                    return Ok();
                }
                else
                    return BadRequest("Kullanıcı adı veya şifre hatalıdır.");
            }
            return BadRequest("Kullanıcı adı veya şifre hatalıdır.");
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp(AppUserAddDto appUserAddDto)
        {
            var user = await _appUserService.FindByEmailandUserName(appUserAddDto.Email, appUserAddDto.UserName);
            if (user != null)
            {
                return BadRequest($"{appUserAddDto.Email} veya {appUserAddDto.UserName} alınmıştır. Başka e-posta adresi deneyiniz.");
            }

            appUserAddDto.Password = _appUserService.CreateHashPassword(appUserAddDto.Password);
            await _appUserService.AddAsync(_mapper.Map<AppUser>(appUserAddDto));



            return Created("", appUserAddDto);
        }


    }
}
