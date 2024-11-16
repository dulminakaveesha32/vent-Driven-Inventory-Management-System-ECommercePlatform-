using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data.Repositories
{
    public class InventoryRepository:IInventoryRepository
    {
        private readonly InventoryDbContext _context;
        public InventoryRepository(InventoryDbContext  context)
        {
            _context= context;
        }

        public async Task AddItemAsync(InventoryModel item)
        {
            _context.Inventories.Add(item);
            await _context.SaveChangesAsync();
            // return item;
        }

        public async Task DeleteItemAsync(int itemId)
        {
            var item =await _context.Inventories.FindAsync(itemId);
            if(item != null)
            {
                _context.Inventories.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<InventoryModel>> GetAllItemsAsync()
        {
            return await _context.Inventories.ToListAsync();
        }

        public async Task<InventoryModel> GetItemByIdAsync(int itemId)
        {
            return await _context.Inventories.FindAsync(itemId);
        }

        public async Task UpdateItemAsync(InventoryModel item)
        {
            _context.Inventories.Update(item);
            await _context.SaveChangesAsync();
            
        }
    }
}