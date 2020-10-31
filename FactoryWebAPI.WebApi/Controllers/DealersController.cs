using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FactoryWebAPI.Business.Interfaces;
using FactoryWebAPI.DTO.DTOs.DealerDtos;
using FactoryWebAPI.Entities.Concrete;
using FactoryWebAPI.WebApi.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FactoryWebAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealersController : ControllerBase
    {
        private readonly IDealerService _dealerService;
        private readonly IMapper _mapper;
        public DealersController(IDealerService dealerService, IMapper mapper)
        {
            _dealerService = dealerService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles="Admin,Member")]
        public async Task<IActionResult> GetAllDealers()
        {
            return Ok(_mapper.Map<List<DealerListDto>>(await _dealerService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        [Authorize(Roles= "Admin,Member")]
        public async Task<IActionResult> GetDealerById(int id)
        {
            return Ok(_mapper.Map<DealerListDto>(await _dealerService.FindByIdAsync(id)));
        }

        [HttpGet("[action]/{id}")]
        [Authorize(Roles= "Admin,Member")]
        public async Task<IActionResult> GetDealersByAppUserId(int id)
        {
            return Ok(_mapper.Map<List<DealerListDto>>(await _dealerService.GetDealersByAppUserId(id)));
        }

        [HttpPost]
        [Authorize(Roles= "Admin, Member")]
        [ValidModel]
        public async Task<IActionResult> AddDealer([FromForm] DealerAddDto dealerAddDto)
        {
            await _dealerService.AddAsync(_mapper.Map<Dealer>(dealerAddDto));
            return Created("", dealerAddDto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles ="Admin,Member")]
        [ValidModel]
        public async Task<IActionResult> UpdateDealer(int id,[FromForm]DealerUpdateDto dealerUpdateDto)
        {
            if (id != dealerUpdateDto.Id)
                return BadRequest("Geçersiz id");

            var updatedDealer =await  _dealerService.FindByIdAsync(id);
            if (updatedDealer != null)
            {
                updatedDealer.Name = dealerUpdateDto.Name;
                updatedDealer.Address = dealerUpdateDto.Address;

                await _dealerService.UpdateAsync(updatedDealer);
                return NoContent();
            }
            else
            {
                return NotFound("Girilen id'ye ait dealer bulunamadı");
            }
            
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDealer(int id)
        {
            var deletedDealer = await _dealerService.FindByIdAsync(id);
            if (deletedDealer !=null)
            {
                deletedDealer.IsVisible = false;
                await _dealerService.UpdateAsync(deletedDealer);
                return NoContent();
            }
            else
            {
                return NotFound("Girilen id'ye ait dealer bulunamadı.");
            }
        
        }

    }
}
