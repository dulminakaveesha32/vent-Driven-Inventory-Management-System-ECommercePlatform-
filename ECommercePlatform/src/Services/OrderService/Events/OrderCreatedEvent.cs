using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Events
{
    public class OrderCreatedEvent
    {
        public int OrderId { get;set; }
        public int ProductId { get;set; } 
        public int Quantity { get;set; }
        public decimal TotalPrice { get;set; }
    }
}