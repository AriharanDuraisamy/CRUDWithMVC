using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Controllers
{
    public class TicketReservationController : Controller
    {
        // GET: TicketReservationController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TicketReservationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TicketReservationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TicketReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketReservationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TicketReservationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketReservationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TicketReservationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
