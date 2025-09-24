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
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace Inventory_Managment_System_Project.Controllers
{
    public class RegistrationController : Controller
    {
        MyContext _context = new MyContext();



        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUp model)
        {
            if (ModelState.IsValid)
            {
                
                var user = new User
                {
                    Username = model.UserName,
                    Email = model.Email,
                    Password = model.Password,  
                    Role = model.Role 
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                TempData["Message"] = "Account created successfully. Please Signin.";
                return RedirectToAction("LogIn");
            }

            return View(model);
        }

        // ------------- SignIn -------------
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(LogIn model)
        {
            if (ModelState.IsValid)
            {
                
                var user = _context.Users.FirstOrDefault(u =>
                    (u.Email == model.UserNameOrEmail || u.Username == model.UserNameOrEmail) &&
                    u.Password == model.Password);

                if (user != null)
                {
                    
                    return RedirectToAction("Dashboard", "Dashboard");
                }
                else
                {
                    ViewBag.Message = "Invalid username/email or password!";
                }
            }
            return View(model);
        }


        public IActionResult LogOut()
        {
            
            return View();
        }

        [HttpPost, ActionName("LogOut")]
        [ValidateAntiForgeryToken]
        public IActionResult LogOutConfirmed()
        {
            
            HttpContext.Session.Clear();
            

            return RedirectToAction("LogIn", "Registration");
        }
    }

}
