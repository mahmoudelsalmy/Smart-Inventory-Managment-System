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
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int UserId { get; set; }


        [ForeignKey("UserId")]
        public virtual User? User { get; set; }

        [StringLength(50)]
        public string? CustomerName { get; set; }


        [Range(0.01, double.MaxValue)]
        public decimal TotalAmount { get; set; }

        [Range(0.01, double.MaxValue)]

        public decimal TotalPrice { get; set; }


        [Required]
        [StringLength(50)]
        public string? Status { get; set; } // Pending / Shipped / Delivered

        public DateTime? OrderDate { get; set; } = DateTime.Now;

        public virtual ICollection<OrderItem>? OrderItems { get; set; }
        public virtual ICollection<Shipment>? Shipments { get; set; }
        public virtual ICollection<Invoices>? Invoices { get; set; }
    }
}
