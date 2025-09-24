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
    public class Shipment
    {
        [Key]
        public int ShipmentId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public Order? Order { get; set; }

        
        public DateTime? ShipmentDate { get; set; } = DateTime.Now;

        
        [StringLength(50)]
        public string? CustomerName { get; set; }
        
        
        [Range(0.01, double.MaxValue)]
        public decimal? TotalAmount { get; set; }
        
        public string? Status { get; set; } // In Transit / Delivered / Returned

    }
}


