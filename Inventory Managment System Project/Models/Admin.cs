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
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }
        
        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]   
        public string? FullName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
       
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
       
    }
}
