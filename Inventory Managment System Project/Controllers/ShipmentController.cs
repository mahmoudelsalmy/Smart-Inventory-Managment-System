using Inventory_Managment_System_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Managment_System_Project.Controllers
{

    public class ShipmentController : Controller
    {
        MyContext _context = new MyContext();


        // GET: Shipment
        public IActionResult Shipment()
        {
            var shipments = _context.Shipments
                .Include(s => s.Order)
                    .ThenInclude(o => o.User) 
                .ToList();

            return View(shipments);
        }

        public IActionResult Create()
        {
            ViewBag.Orders = new SelectList(
                _context.Orders.Include(o => o.User)
                               .Select(o => new
                               {
                                   o.OrderId,
                                   DisplayText = o.OrderId + " - " + o.User.Username
                               })
                               .ToList(),
                "OrderId",
                "DisplayText"
            );

            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                shipment.ShipmentDate = DateTime.Now;
                _context.Shipments.Add(shipment);
                _context.SaveChanges();
                return RedirectToAction(nameof(Shipment));
            }

            
            ViewBag.Orders = new SelectList(
                _context.Orders.Include(o => o.User)
                               .Select(o => new
                               {
                                   o.OrderId,
                                   DisplayText = o.OrderId + " - " + o.User.Username
                               })
                               .ToList(),
                "OrderId",
                "DisplayText",
                shipment.OrderId
            );

            return View(shipment);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var shipment = _context.Shipments.Find(id);
            if (shipment == null)
            {
                return NotFound();
            }

            ViewBag.Orders = new SelectList(
                _context.Orders.Include(o => o.User)
                               .Select(o => new
                               {
                                   o.OrderId,
                                   DisplayText = o.OrderId + " - " + o.User.Username
                               })
                               .ToList(),
                "OrderId",
                "DisplayText",
                shipment.OrderId 
            );

            return View(shipment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                _context.Shipments.Update(shipment);
                _context.SaveChanges();
                return RedirectToAction(nameof(Shipment));
            }

            // نفس الحاجة لو ModelState مش Valid
            ViewBag.Orders = new SelectList(
                _context.Orders.Include(o => o.User)
                               .Select(o => new
                               {
                                   o.OrderId,
                                   DisplayText = o.OrderId + " - " + o.User.Username
                               })
                               .ToList(),
                "OrderId",
                "DisplayText",
                shipment.OrderId
            );

            return View(shipment);
        }

        public IActionResult Delete(int id)
        {
            var shipment = _context.Shipments
                .Include(s => s.Order)
                    .ThenInclude(o => o.User)
                .FirstOrDefault(s => s.ShipmentId == id);

            if (shipment == null)
            {
                return NotFound();
            }

            return View(shipment);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var shipment = _context.Shipments.Find(id);
            if (shipment != null)
            {
                _context.Shipments.Remove(shipment);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Shipment));
        }


        public IActionResult Details()
        {
            return View(Details);
        }

    }
}