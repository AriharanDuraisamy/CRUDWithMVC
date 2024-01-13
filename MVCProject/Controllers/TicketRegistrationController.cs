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
        private readonly ITicketRegistration _Register;
        private readonly string _connectionstring;
        public TicketRegistrationController(ITicketRegistration reg, IConfiguration configuration)
        {
            _Register = reg;
            _connectionstring = configuration.GetConnectionString("DbConnection");
        }
        // GET: RegistrationController
        public ActionResult Index()
        {
            var Results = _Register.GetAllRegistration();
            return View("List",Results);
        }
        // GET: RegistrationController/Create
        public ActionResult Create(Registration value)
        {
            var model = _Register.Security(value);
            if (model == true)
            {
                var ans = _Register.GetAllRegistration(value);
                return View("Create", ans);
            }
            else
            {
                return Redirect("/Login/Login");
            }

           /* var model = new Registration();
            return View("Create",model);*/
        }

        // POST: RegistrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Creates( Registration detail)
        {
            var model = _Register.Login(detail);
            try
            {
                if(model==true)
                {
                    _Register.Insert(detail);
                    return Redirect("/Login/Login");
                }
                else
                {
                    
                    return View( "Create");
                }
               
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Details(long id)
        {
            var tkt =_Register.ReadbyID(id);
            return View("Details", tkt);
        }
    }
}

