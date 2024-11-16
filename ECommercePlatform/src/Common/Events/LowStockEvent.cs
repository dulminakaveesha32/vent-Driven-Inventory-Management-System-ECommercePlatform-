using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Events
{
    public class LowStockEvent
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int CurrentStock { get; set; }
        public int Threshold { get; set; }
        public DateTime AlertedAt { get; set; }

        public LowStockEvent(Guid productId, string productName, int currentStock, int threshold, DateTime alertedAt)
        {
            ProductId = productId;
            ProductName = productName;
            CurrentStock = currentStock;
            Threshold = threshold;
            AlertedAt = alertedAt;
        }
    }
}