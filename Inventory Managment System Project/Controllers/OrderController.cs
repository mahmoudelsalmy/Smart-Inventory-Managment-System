using Inventory_Managment_System_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Managment_System_Project.Controllers
{

    public class OrderController : Controller
    {
        MyContext _context = new MyContext();

        public async Task<IActionResult> Order()
        {
            var orders = _context.Orders
                                 .Include(o => o.User) 
                                 .ToList();
            return View(orders);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            var users = _context.Users
                .Select(u => new { u.UserId, u.Username })
                .ToList();

            
            ViewBag.Users = new SelectList(users, "UserId", "Username");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                order.OrderDate = DateTime.Now; 
                _context.Orders.Add(order);
                _context.SaveChanges();
                return RedirectToAction(nameof(Order));
            }

            
            ViewBag.Users = new SelectList(_context.Users, "UserId", "Username");
            return View(order);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            ViewBag.Users = new SelectList(_context.Users.ToList(), "UserId", "Username", order.UserId);
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                order.OrderDate = DateTime.Now;
                var existingOrder = _context.Orders.Find(order.OrderId);
                if (existingOrder == null)
                {
                    return NotFound();
                }

                
                existingOrder.UserId = order.UserId;
                existingOrder.TotalAmount = order.TotalAmount;
                existingOrder.TotalPrice = order.TotalPrice;
                existingOrder.Status = order.Status;
                

                _context.SaveChanges();
                return RedirectToAction(nameof(Order));
            }

            ViewBag.Users = new SelectList(_context.Users, "UserId", "UserName", order.UserId);
            return View(order);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var order = _context.Orders
                .FirstOrDefault(c => c.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order); 
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            _context.SaveChanges();

            return RedirectToAction(nameof(Order));
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}


