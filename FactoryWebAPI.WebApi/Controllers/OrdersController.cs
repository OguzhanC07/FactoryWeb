using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FactoryWebAPI.Business.Interfaces;
using FactoryWebAPI.DTO.DTOs.OrderDetailDtos;
using FactoryWebAPI.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FactoryWebAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IDealerService _dealerService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public OrdersController(IProductService productService,IDealerService dealerService, IMapper mapper, IOrderDetailService orderDetailService)
        {
            _mapper = mapper;
            _orderDetailService = orderDetailService;
            _dealerService = dealerService;
            _productService = productService;
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _dealerService.GetAllOrders();

            List<OrderDetailListDto> orderDetailsList = new List<OrderDetailListDto>();

            foreach (var order in orders)
            {
                OrderDetailListDto orderDetail = new OrderDetailListDto
                {
                    Id = order.Id,
                    NumberOfOrders = order.NumberOfOrders,
                    BuyTime = order.BuyTime,
                    ProductName = order.Product.Name,
                    DealerName = order.Dealer.Name
                };

                orderDetailsList.Add(orderDetail);
            }

            return Ok(orderDetailsList);
        }

        [HttpGet("{id}")]
        [Authorize(Roles ="Admin,Member")]
        public async Task<IActionResult> GetAllOrdersByAppUserId(int id)
        {
            var orders = await _dealerService.GetOrdersByAppUserIdAsync(id);

            List<OrderDetailListDto> orderDetailList = new List<OrderDetailListDto>();

            foreach (var order in orders)
            {
                OrderDetailListDto orderDetail = new OrderDetailListDto
                {
                    Id = order.Id,
                    BuyTime=order.BuyTime,
                    DealerName=order.Dealer.Name,
                    NumberOfOrders=order.NumberOfOrders,
                    ProductName=order.Product.Name
                };

                orderDetailList.Add(orderDetail);
            }

            return Ok(orderDetailList);
        }

        [HttpPost]
        [Authorize(Roles ="Admin,Member")]
        public async Task<IActionResult> AddNewOrder([FromForm] OrderAddDto orderAdd)
        {
            var product = await _productService.FindByIdAsync(orderAdd.ProductId);
            var dealer = await _dealerService.FindByIdAsync(orderAdd.DealerId);

            if (product == null)
            {
                return BadRequest("Gönderilen ürün veya satıcıda sorun var lütfen kontrol ediniz");
            }
            else if(dealer==null)
            {
                return BadRequest("Gönderilen ürün veya satıcıda sorun var lütfen kontrol ediniz");
            }
            else
            {
                orderAdd.BuyTime = DateTime.Now;
                await _orderDetailService.AddAsync(_mapper.Map<OrderDetail>(orderAdd));
                return Created("", orderAdd);
            }
        }
    }
}
