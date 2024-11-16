using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryService.Models;

namespace InventoryService.Data.Repositories
{
    public interface IInventoryRepository
    {
        Task<InventoryModel>GetItemByIdAsync(int itemId);
        Task<IEnumerable<InventoryModel>> GetAllItemsAsync();
        Task AddItemAsync (InventoryModel item);
        Task UpdateItemAsync (InventoryModel item);
        Task DeleteItemAsync (int itemId);
    }
}