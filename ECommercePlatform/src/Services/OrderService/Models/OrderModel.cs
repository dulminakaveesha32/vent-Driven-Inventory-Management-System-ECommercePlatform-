using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get;set; }
        public int ProductId { get;set; }
        public int Quantity { get;set; }
        public decimal TotalPrice { get;set; }
        public DateTime OrderDate { get;set; }
        
    }
}