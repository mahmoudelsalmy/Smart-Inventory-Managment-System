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
    public class Warehouse
    {
        [Key]
        public int WarehouseId { get; set; }

        [Required]
        [StringLength(100)]
        public string? WarehouseName { get; set; }

        [Required]
        [StringLength(200)]
        public string? Location { get; set; }

        
        public string? ManagerName { get; set; }

        public int Capacity { get; set; }

        public ICollection<StockMovement>? Inventories { get; set; }
    }
}
