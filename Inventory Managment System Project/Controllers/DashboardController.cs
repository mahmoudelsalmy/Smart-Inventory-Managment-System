using Inventory_Managment_System_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Inventory_Managment_System_Project.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        MyContext _context = new MyContext();

        public IActionResult Dashboard()
        {
            var dashboard = new Dashboard
            {
                TotalProducts = _context.Products.Count(),
                TotalOrders = _context.Orders.Count(),
                TotalRevenue = _context.Orders.Sum(o => (double?)o.TotalPrice) ?? 0,
                LowStockItems = _context.Products.Count(p => p.Stock < 15),

                RecentProducts = _context.Products
                                         .Include(p => p.Category)   
                                         .OrderByDescending(p => p.ProductId)
                                         .Take(5)
                                         .ToList(),

                RecentOrders = _context.Orders
                                       .Include(o => o.User)
                                       .OrderByDescending(o => o.OrderId)
                                       .Take(5)
                                       .ToList()
            };

            return View(dashboard);
        }



    }
}

