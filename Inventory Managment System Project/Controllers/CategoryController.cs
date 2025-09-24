using Inventory_Managment_System_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Managment_System_Project.Controllers
{
    
    public class CategoryController : Controller
    {
        MyContext _context = new MyContext();
        public IActionResult Category()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                category.CategoryId = 0; 
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Category));
            }
            return View(category);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var existingCategory = _context.Categories.Find(category.CategoryId);
                if (existingCategory == null)
                {
                    return NotFound();
                }

                
                existingCategory.CategoryName = category.CategoryName;
                existingCategory.Description = category.Description;

                _context.SaveChanges();
                return RedirectToAction(nameof(Category)); 
            }

            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories
                .FirstOrDefault(c => c.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category); 
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Category));
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
