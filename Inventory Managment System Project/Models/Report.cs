using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inventory_Managment_System_Project.Models;

namespace Inventory_Managment_System_Project.Models
{
    [Keyless]
    public class Report
    {
        
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? CategoryName { get; set; }
        public int? Stock { get; set; }
        public decimal? Price { get; set; }
        public int? TotalOrders { get; set; }
        public int? TotalRevenue { get; set; }
        public string? UserName { get; set; }

        //public Order? Orders { get; set; } 

        public List<Product>? Products { get; set; }
        public List<Order>? Orders { get; set; }

    }
}
