using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryService.Models;

namespace InventoryService.Services
{
    public interface IInventoryService
    {
        Task<InventoryModel> GetItemAsync(int id);
        Task<IEnumerable<InventoryModel>> GetAllItemsAsync();
        Task AddItemAsync(InventoryModel item);
        Task UpdateItemAsync(InventoryModel item);
        Task DeleteItemAsync(int id);
    }
}