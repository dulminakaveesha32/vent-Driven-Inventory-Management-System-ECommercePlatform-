using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Models;

namespace OrderService.Data.Repositories
{
    public interface IOrderRepository
    {
        Task<OrderModel> GetOrderByIdAsync(int OrderId);
        Task<IEnumerable<OrderModel>>GetAllOrdersAsync();
        Task AddOrderAsync(OrderModel order);
        Task UpdateOrderAsync(OrderModel order);
        Task DeleteOrderAsync(int orderId );
    }
}