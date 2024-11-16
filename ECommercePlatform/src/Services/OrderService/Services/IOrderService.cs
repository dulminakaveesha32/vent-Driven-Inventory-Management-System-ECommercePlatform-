using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Models;

namespace OrderService.Services
{
    public interface IOrderService
    {
        Task<OrderModel> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<OrderModel>> GetAllOrdersAsync ();
        Task AddOrderAsync (OrderModel order);
        Task UpdateOrderAsync (int orderId, OrderModel order);
        Task DeleteOrderAsync (int orderId);
    }
}