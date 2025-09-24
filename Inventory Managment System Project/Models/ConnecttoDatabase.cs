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
        private readonly MyContext context;

        public ConnecttoDatabase()
        {
            context = new MyContext();
        }

        // CRUD 
        public void AddCategory(Category category)
        {
            context.Add(category);
            context.SaveChanges();
        }
        public List<Category> GetCategories()
        {
            return context.Categories.ToList();
        }
        public Category GetCategoryById(int id)
        {
            return context.Categories.FirstOrDefault(d => d.CategoryId == id); ;
        }
        public void UpdateCategory(Category category)
        {
            context.Update(category);
            context.SaveChanges();
        }
        public void DeleteCategory(int id)
        {
            var category = context.Categories.Find(id);
            if (category != null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }
        public List<Category> GetAllCategories()
        {
            return context.Categories.ToList();
        }
    }
}
