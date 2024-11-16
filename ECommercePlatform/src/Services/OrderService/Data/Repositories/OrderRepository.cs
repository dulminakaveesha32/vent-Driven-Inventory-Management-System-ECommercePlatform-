using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderService.Models;

namespace OrderService.Data.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        private readonly OrderDbContext _context;
        public OrderRepository(OrderDbContext context)
        {
            _context =context;
        }

        public async Task AddOrderAsync(OrderModel order)
        {
            _context.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if(order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<IEnumerable<OrderModel>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<OrderModel> GetOrderByIdAsync(int OrderId)
        {
            return await _context.Orders.FindAsync(OrderId);
        }

        public async Task UpdateOrderAsync(OrderModel order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}