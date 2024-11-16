using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Events
{
    public class InventoryUpdatedEvent
    {
        public Guid ProductId { get; set; }
        public int NewQuantity { get; set; }
        public int QuantityChange { get; set; }
        public DateTime UpdatedAt { get; set; }

        public InventoryUpdatedEvent(Guid productId, int newQuantity, int quantityChange, DateTime updatedAt)
        {
            ProductId = productId;
            NewQuantity = newQuantity;
            QuantityChange = quantityChange;
            UpdatedAt = updatedAt;
        }
    }
}