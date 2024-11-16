using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryService.Data.Repositories;
using InventoryService.Models;

namespace InventoryService.Services
{
    public class InventoryService:IInventoryService
    {
        private readonly IInventoryRepository _repository;
        public InventoryService(IInventoryRepository repository)
        {
            _repository = repository;
        }

        public async Task AddItemAsync(InventoryModel item)
        {
            await _repository.AddItemAsync(item);
        }

        public async Task DeleteItemAsync(int id)
        {
            await _repository.DeleteItemAsync(id);
        }

        public async Task<IEnumerable<InventoryModel>> GetAllItemsAsync()
        {
            return await _repository.GetAllItemsAsync();
        }

        public async Task<InventoryModel> GetItemAsync(int id)
        {
            return await _repository.GetItemByIdAsync(id);
        }

        public async Task UpdateItemAsync(InventoryModel item)
        {
            await _repository.UpdateItemAsync(item);
        }
    }
}