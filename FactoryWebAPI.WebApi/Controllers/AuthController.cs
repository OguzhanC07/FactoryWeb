﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FactoryWebAPI.Business.Interfaces;
using FactoryWebAPI.Business.StringInfo;
using FactoryWebAPI.DTO.DTOs.AppUserDtos;
using FactoryWebAPI.DTO.DTOs.ForgotPasswordDtos;
using FactoryWebAPI.Entities.Concrete;
using FactoryWebAPI.WebApi.CustomFilters;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IMailService _mailService;
        private readonly IForgotPasswordService _forgotPasswordService;
        public AuthController(IForgotPasswordService forgotPasswordService, IMailService mailService, IJwtService jwtService, IMapper mapper, IAppUserService appUserService)
        {
            _appUserService = appUserService;
            _mapper = mapper;
            _jwtService = jwtService;
            _mailService = mailService;
            _forgotPasswordService = forgotPasswordService;
        }


        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
            var user = await _appUserService.FindByEmailorUserName(appUserLoginDto.Email);
            if (user != null)
            {
                appUserLoginDto.Password = _appUserService.CreateHashPassword(appUserLoginDto.Password);
                if (await _appUserService.CheckHashPassword(appUserLoginDto) && user.BanEndTime<=DateTime.Now)
                {
                    var roles = await _appUserService.GetRolesByEmail(appUserLoginDto.Email);
                    var token = _jwtService.GenerateJwt(user, roles);

                    return Created("", token);
                }
                else
                {
                    if (user.BanCount>=3)
                    {
                        user.BanCount = 0;
                        user.BanEndTime = DateTime.Now.AddMinutes(60);
                        await _appUserService.UpdateAsync(user);
                        return BadRequest($"Çok fazla giriş yapmaya çalıştınız.{user.BanEndTime.ToLongDateString()}-{user.BanEndTime.ToLongTimeString()}'e kadar giriş yapamazsınız");
                    }
                    else
                    {
                        if (user.BanEndTime>=DateTime.Now)
                        {
                            return BadRequest($"Çok fazla giriş yapmaya çalıştınız.{user.BanEndTime.ToLongDateString()}-{user.BanEndTime.ToLongTimeString()}'e kadar giriş yapamazsınız");
                        }
                        user.BanCount += 1;
                        await _appUserService.UpdateAsync(user);
                        return BadRequest("Kullanıcı adı veya şifre hatalıdır.");
                    }
                }
            }
            return BadRequest("Kullanıcı adı veya şifre hatalıdır.");
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp([FromForm] AppUserAddDto appUserAddDto, [FromServices] IAppUserRoleService appUserRoleService, [FromServices] IAppRoleService appRoleService)
        {
            var appUser = await _appUserService.FindByEmailorUserName(appUserAddDto.Email);
            if (appUser != null)
            {
                return BadRequest($"{appUserAddDto.Email} veya {appUserAddDto.UserName} alınmıştır. Başka e-posta adresi veya kullanıcı adı deneyiniz.");
            }

            appUserAddDto.Password = _appUserService.CreateHashPassword(appUserAddDto.Password);
            appUserAddDto.ImagePath = "default.jpg";
            await _appUserService.AddAsync(_mapper.Map<AppUser>(appUserAddDto));

            var user = await _appUserService.FindByEmailorUserName(appUserAddDto.UserName);
            var role = await appRoleService.FindByNameAsync(RoleInfo.Member);

            await appUserRoleService.AddAsync(new AppUserRole
            {
                AppRoleId = role.Id,
                AppUserId = user.Id
            });

            await _mailService.SendWelcomeMailAsync(user.UserName, user.Email);
            return Created("", appUserAddDto);
        }


        [HttpGet("[action]")]
        [Authorize(Roles = "Admin,Member")]
        public async Task<IActionResult> GetActiveUser()
        {
            var user = await _appUserService.FindByEmailorUserName(User.Identity.Name);
            var roles = await _appUserService.GetRolesByEmail(user.Email);

            AppUserDto appUserDto = new AppUserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                UserName = user.UserName,
                Roles = roles.Select(I => I.Name).ToList()
            };

            return Ok(appUserDto);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> ForgotPassword([FromForm]string email)
        {
            var user = await _appUserService.FindByEmailorUserName(email);
            if (user!=null)
            {
                string code = _forgotPasswordService.GenerateRandomPass();
                await _forgotPasswordService.MakeAllCodesFalseAsync(user.Id);
                await _forgotPasswordService.AddAsync(new ForgotPassword
                {
                    AppUserId = user.Id,
                    Code =code,
                    isActive = true
                });
                await _mailService.SendForgotPasswordCodeAsync(code, email);
                return Ok();
            }
            else
            {
                return NotFound("Böyle bir kullanıcı bulunmamaktadır");
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ResetPassword([FromForm]ForgotPasswordDto forgotPassDto)
        {
            var user = await _appUserService.FindByEmailorUserName(forgotPassDto.Email);
            if (await _forgotPasswordService.GetCodeAsync(user.Id,forgotPassDto.Code))
            {
                user.Password = _appUserService.CreateHashPassword(forgotPassDto.Password);
                await _appUserService.UpdateAsync(user);
                return Ok(); 
            }
            else
            {
                return BadRequest("Kodu yanlış girdiniz");
            }
        }

    }
}
