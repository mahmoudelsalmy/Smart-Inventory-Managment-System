using Inventory_Managment_System_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inventory_Managment_System_Project.Controllers
{

    public class InvoicesController : Controller
    {
        MyContext _context = new MyContext();

        public IActionResult Invoices()
        {
            var invoice = _context.Invoices
                .Include(s => s.Order)
                    .ThenInclude(o => o.User) 
                .ToList();

            return View(invoice);
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
        public IActionResult Create(Invoices invoices)
        {
            if (ModelState.IsValid)
            {
                invoices.InvoiceDate = DateTime.Now;
                _context.Invoices.Add(invoices);
                _context.SaveChanges();
                return RedirectToAction(nameof(Invoices));
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
                invoices.OrderId
            );

            return View(invoices);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var invoice = _context.Invoices.Find(id);
            if (invoice == null)
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
                invoice.OrderId 
            );

            return View(invoice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Invoices invoice)
        {
            if (ModelState.IsValid)
            {
                _context.Invoices.Update(invoice);
                _context.SaveChanges();
                return RedirectToAction(nameof(Invoices));
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
                invoice.OrderId
            );

            return View(invoice);
        }

        public IActionResult Delete(int id)
        {
            var invoice = _context.Invoices
                .Include(s => s.Order)
                    .ThenInclude(o => o.User)
                .FirstOrDefault(s => s.InvoiceId == id);

            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var invoice = _context.Invoices.Find(id);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Invoices));
        }


        public IActionResult Details()
        {
            return View(Details);
        }
    }
}