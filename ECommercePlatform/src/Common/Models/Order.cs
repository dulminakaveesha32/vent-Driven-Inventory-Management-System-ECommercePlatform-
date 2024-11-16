using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Order
    {
        public Guid OverId { get;set; }
        public Guid ProductId { get;set; }
        public int Quantity { get;set; }
        public decimal TotalPrice { get;set; }
        
    }
}