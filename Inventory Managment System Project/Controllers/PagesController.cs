using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inventory_Managment_System_Project.Models;

namespace Inventory_Managment_System_Project.Controllers
{

    public class PagesController : Controller
    {
        private readonly MyContext _context;

        public PagesController(MyContext context)
        {
            _context = context;
        }

        //public IActionResult Dashboard()
        //{
        //    var model = new Dashboard
        //    {
        //        TotalProducts = 120,
        //        TotalOrders = 45,
        //        TotalRevenue = (double)98765.50m,
        //        LowStockItems = 3,
        //        RecentProducts = new List<Product>
        //        {
        //            new Product { Name = "Laptop", Price = 1500, Stock = 10, Category= "Electronics" },
        //            new Product { Name = "Phone", Price = 800, Stock = 20, Category = "Electronics" }
        //        },
        //        RecentOrders = new List<Order>
        //        {
        //            new Order { OrderId = 1, CustomerName = "Mahmoud", TotalAmount = 2300, Status = "Completed" },
        //            new Order { OrderId = 2, CustomerName = "Ali", TotalAmount = 1200, Status = "Pending" }
        //        }
        //    };

        //    return View(model);
        //}

        //public IActionResult Product()
        //{
        //    var products = _context.Products.ToList(); // جلب المنتجات من الداتا بيس
        //    return View(products);
        //}

        //public IActionResult Warehouse()
        //{
        //    return View();
        //}

        //public IActionResult Order()
        //{
        //    return View();
        //}

        //public IActionResult Category()
        //{
        //    return View();
        //}

        //public IActionResult Invoices()
        //{
        //    return View();
        //}

        //public IActionResult Shipment()
        //{
        //    return View();
        //}

        //public IActionResult Reports()
        //{
        //    return View();
        //}



    }
}
