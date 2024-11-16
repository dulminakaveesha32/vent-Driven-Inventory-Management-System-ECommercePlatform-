using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Data.Repositories;
using OrderService.Models;

namespace OrderService.Services
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository =orderRepository;
        }

        public async Task AddOrderAsync(OrderModel order)
        {
            await _orderRepository.AddOrderAsync(order);
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            await _orderRepository.DeleteOrderAsync(orderId);
        }

        public async Task<IEnumerable<OrderModel>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllOrdersAsync();
        }

        public async Task<OrderModel> GetOrderByIdAsync(int orderId)
        {
            return await _orderRepository.GetOrderByIdAsync(orderId);
        }

        public async Task UpdateOrderAsync( int orderId ,OrderModel order)
        {
            var ex = await _orderRepository.GetOrderByIdAsync(orderId);
            if(ex!= null)
            {
                ex.ProductId = order.ProductId;
                ex.OrderDate = order.OrderDate;
                ex.TotalPrice = order.TotalPrice;
                ex.Quantity = order.Quantity;

                await _orderRepository.UpdateOrderAsync(ex);
            }
        }
    }
}