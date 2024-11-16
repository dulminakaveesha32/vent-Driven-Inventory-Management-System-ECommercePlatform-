using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Events
{
    public class OrderPlacedEvent
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }

        public OrderPlacedEvent(Guid orderId, Guid productId, int quantity, decimal totalPrice, DateTime orderDate, Guid customerId)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            TotalPrice = totalPrice;
            OrderDate = orderDate;
            CustomerId = customerId;
        }   
    }
}