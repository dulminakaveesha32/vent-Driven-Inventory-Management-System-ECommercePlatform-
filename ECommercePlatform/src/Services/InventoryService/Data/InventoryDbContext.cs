using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data
{
    public class InventoryDbContext:DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options):base(options)
        {

        }
        public DbSet<InventoryModel> Inventories {get;set; }
        
    }
}