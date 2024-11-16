using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Product
    {
        public Guid ProductId { get;set; }
        public string? Name { get;set; }
        public decimal Price { get;set; }
        
    }
}