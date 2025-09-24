using Inventory_Managment_System_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Managment_System_Project.Controllers
{

    public class WarehouseController : Controller
    {
        MyContext _context = new MyContext();

        public IActionResult Warehouse()
        {
            var warehouse = _context.Warehouses.ToList();
            return View(warehouse);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                warehouse.WarehouseId = 0;
                _context.Add(warehouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Warehouse));
            }
            return View(warehouse);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var warehouse = _context.Warehouses.Find(id);
            if (warehouse == null)
            {
                return NotFound();
            }

            return View(warehouse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                var existingWarehouse = _context.Warehouses.Find(warehouse.WarehouseId);
                if (existingWarehouse == null)
                {
                    return NotFound();
                }

                
                existingWarehouse.WarehouseName = warehouse.WarehouseName;
                existingWarehouse.ManagerName = warehouse.ManagerName;
                existingWarehouse.Location = warehouse.Location;
                existingWarehouse.Capacity = warehouse.Capacity;
            

                _context.SaveChanges();
                return RedirectToAction(nameof(Warehouse)); 
            }

            return View(warehouse);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var warehouse = _context.Warehouses
                .FirstOrDefault(c => c.WarehouseId == id);

            if (warehouse == null)
            {
                return NotFound();
            }

            return View(warehouse); 
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var warehouse = _context.Warehouses.Find(id);
            if (warehouse == null)
            {
                return NotFound();
            }

            _context.Warehouses.Remove(warehouse);
            _context.SaveChanges();

            return RedirectToAction(nameof(Warehouse));
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}