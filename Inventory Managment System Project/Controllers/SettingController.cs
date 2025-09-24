using Inventory_Managment_System_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Managment_System_Project.Controllers
{

    public class SettingController : Controller
    {
        MyContext _context = new MyContext();
       


        //public async Task<IActionResult> Profile()
        //{
        //    var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        //    if (userId == null)
        //    {
        //        return RedirectToAction("LogIn", "Registration");
        //    }

        //    var user = await _context.Users.FindAsync(userId);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(user);
        //}


        public IActionResult Notification()
        {
            int lowStockThreshold = 15; 

            var lowStockItems = _context.Products
                .Include(p => p.Category)
                .Where(p => p.Stock <= lowStockThreshold)
                .ToList();

            return View(lowStockItems);
        }
    }
}
