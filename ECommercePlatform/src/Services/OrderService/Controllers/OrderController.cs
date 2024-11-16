using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderService.Events;
using OrderService.Kafka;
using OrderService.Models;
using OrderService.Services;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController:ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly OrderProducer _orderProducer;

        public OrderController(IOrderService orderService , OrderProducer orderProducer)
        {
            _orderProducer = orderProducer;
            _orderService = orderService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderModel>> GetOrder(int id)
        {
            var order =await _orderService.GetOrderByIdAsync(id);
            if(order==null) return NotFound();
            return Ok();
        } 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderModel>>>GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }
        [HttpPost]
        public async Task<ActionResult> CreateOrder(OrderModel order)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Submit Fail");
            }
            await _orderService.AddOrderAsync(order);
            var orderEvent = new OrderCreatedEvent
            {
                OrderId = order.OrderId,
                ProductId =order.ProductId,
                Quantity = order.Quantity,
                TotalPrice = order.TotalPrice
            };
            await _orderProducer.PublishOrderCreatedAsync(orderEvent);
            return CreatedAtAction(nameof(GetOrder), new{ id = order.OrderId} , order);
        }


    }
}