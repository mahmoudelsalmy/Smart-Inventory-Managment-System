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
    public class LogIn
    {
        [Required(ErrorMessage = "Username or Email is required")]
        [StringLength(50)]
        public string? UserNameOrEmail { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }


    }
}
