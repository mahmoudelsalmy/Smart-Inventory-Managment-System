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
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        
        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(100)]
        [Display(Name = "Product Name")]
        public string? Name { get; set; }

        [ForeignKey("CategoryId")]
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }

        public int? Stock { get; set; }

        public Category? Category { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than or equal to 0")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater than or equal to 0")]
        public int? Quantity { get; set; }

        
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [StringLength(400)]
        public string? Description { get; set; }

        public virtual ICollection<StockMovement>? Inventories { get; set; }
        public virtual ICollection<OrderItem>? OrderItems { get; set; }

    }
}
