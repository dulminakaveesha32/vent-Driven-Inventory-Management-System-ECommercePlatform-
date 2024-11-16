using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Events
{
    public class InventoryUpdatedEvent
    {
        public int ItemId { get; set; }
        public int QuantityChange { get; set; }
        public string EventType { get; set; } 
    }
}