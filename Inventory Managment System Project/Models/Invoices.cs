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
    public class Invoices
    {
        [Key]

        public int InvoiceId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public Order? Order { get; set; }


        
        [StringLength(50)]
        public string? CustomerName { get; set; }
       
        
        
        [Range(0.01, double.MaxValue)]
        public decimal? TotalPrice { get; set; }

        public DateTime? InvoiceDate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        public string? Status { get; set; } // Paid / Unpaid / Overdue

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
