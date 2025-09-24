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
    public class Dashboard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DashboardId { get; set; }
        public int TotalProducts { get; set; }
        public int TotalOrders { get; set; }
        public double TotalRevenue { get; set; }
        public int LowStockItems { get; set; }
        public List<Product>? RecentProducts { get; set; }
        public List<Order>? RecentOrders { get; set; }
    }
}
