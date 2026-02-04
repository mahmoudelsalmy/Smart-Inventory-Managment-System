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
    public class ConnecttoDatabase
    {
        private readonly MyContext _context;

        public ConnecttoDatabase(MyContext context)
        {
            _context = context;
        }

        // CRUD 
        public void AddCategory(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
        }
        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
        public Category GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(d => d.CategoryId == id); ;
        }
        public void UpdateCategory(Category category)
        {
            _context.Update(category);
            _context.SaveChanges();
        }
        public void DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
