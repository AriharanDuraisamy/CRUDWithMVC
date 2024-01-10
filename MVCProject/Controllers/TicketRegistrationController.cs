using EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using DapperDataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace MVCProject.Controllers
{
    public class TicketRegistrationController : Controller
    {
        private readonly ITicketRegistration Register;
        private readonly string _connectionstring;
        public TicketRegistrationController(ITicketRegistration reg, IConfiguration configuration)
        {
            Register = reg;
            _connectionstring = configuration.GetConnectionString("DbConnection");
        }
        // GET: RegistrationController
       /* public ActionResult Index()
        {
            return View("List",Register.GetAllRegistration());
        }*/
        // GET: RegistrationController/Create
        public ActionResult Create()
        {
            var model = new Registration();
            return View("Create", model);

           /* var model = new Registration();
            return View("Create",model);*/
        }

        // POST: RegistrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Registration detail)
        {
            try
            {
                Register.Insert(detail);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private object LoginForm()
        {
            throw new NotImplementedException();
        }

        public IActionResult Login()
        {
            return View("LoginForm", new LoginModel());
        }
        /* public ActionResult Registers()
         {
             Register.GetAllRegistration();
             return View("");
         }*/
    }

}

