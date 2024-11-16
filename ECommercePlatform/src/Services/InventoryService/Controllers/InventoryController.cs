using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryService.Models;
using InventoryService.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController:ControllerBase
    {
       private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryModel>>> GetAll()
        {
            return Ok(await _inventoryService.GetAllItemsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryModel>> Get(int id)
        {
            var item = await _inventoryService.GetItemAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] InventoryModel item)
        {
            await _inventoryService.AddItemAsync(item);
            return CreatedAtAction(nameof(Get), new { id = item.ItemId }, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] InventoryModel item)
        {
            item.ItemId = id;
            await _inventoryService.UpdateItemAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _inventoryService.DeleteItemAsync(id);
            return NoContent();
        }
    }
}