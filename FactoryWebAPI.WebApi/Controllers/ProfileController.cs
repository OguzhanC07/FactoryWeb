using AutoMapper;
using FactoryWebAPI.Business.Interfaces;
using FactoryWebAPI.DTO.DTOs.AppUserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryWebAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Member")]
    public class ProfileController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IAppUserService _appUserService;
        public ProfileController(IAppUserService appUserService, IMapper mapper)
        {
            _mapper = mapper;
            _appUserService = appUserService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<ProfileDto>(await _appUserService.FindByIdAsync(id)));
        }
    }
}
