using DapperDataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MVCProject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View("LoginForm",new LoginModel());
        }
        /*public ActionResult Create(Registration value)
        {
            var model = _Registers.Security(value);
            if (model == true)
            {
                var ans = _Registers.GetAllRegistration(value);
                return View("Create", ans);
            }

            *//* var model = new Registration();
             return View("Create",model);*//*
        }
*/


        /*public ActionResult Login(LoginModel log)
        {
            // Assuming you have a method to authenticate users in your data access layer
            bool isValid = DapperDataAccessLayer.ValidateUser(log.EmailID, log.Password);
            if (isValid)
            {
                // Authentication successful, perform necessary actions (e.g., set authentication cookie)
                return RedirectToAction("/Home/Index"); // Redirect to a dashboard or home page
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View("LoginForm",log); // Return to the login page with an error message
            }
        }*/
        /* [HttpPost]
         public IActionResult Login(LoginModel log)
         {
             return Redirect("/Home/IndeX");

         }*/
    }
}
