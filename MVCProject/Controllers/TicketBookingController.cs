using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperDataAccessLayer;

namespace MVCProject.Controllers
{
    public class TicketBookingController : Controller
    {
        private readonly ITicketSP Detail;

        public TicketBookingController()
        {
            Detail = new TicketBookingSP();
        }
        public ActionResult Index()
        {
            var ticket = Detail.ReadSP();
            return View("View" , ticket);
        }

        // GET: TicketBookingController1/Details/5
        public ActionResult Details(int id)
        {
            var ticket = Detail.ReadbyIDSP(id);
            return View("Details",ticket);
        }

        // GET: TicketBookingController1/Create
        public ActionResult Create()
        {
            return View("AddDetails", new TicketModelSP());
        }

        // POST: TicketBookingController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(TicketModelSP tkt)
        {
            try
            {
                Detail.InsertSP(tkt);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketBookingController1/Edit/5
        public ActionResult Edit(int id)
        {
            var tkt = Detail.ReadbyIDSP(id);
            return View("Edit",tkt);
        }

        // POST: TicketBookingController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,TicketModelSP tkt)
        {
            try
            {
                Detail.UpdateSP(id, tkt);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketBookingController1/Delete/5
        public ActionResult Delete(int id)
        {
            var tkt = Detail.ReadbyIDSP(id);
            return View("Delete",tkt);
        }

        // POST: TicketBookingController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TicketModelSP tkt)
        {
            try
            {
                Detail.DeleteSP(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
