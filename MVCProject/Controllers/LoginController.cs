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
       /* [HttpPost]
        public IActionResult Login(LoginModel log)
        {
            return Redirect("/Home/IndeX");
                
        }*/
    }
}
