using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperDataAccessLayer;
using Microsoft.Extensions.Configuration;

namespace MVCProject.Controllers
{
    public class TicketBookingController : Controller
    {
        private readonly ITicketBooking _Result;
        private readonly ITicketLocations _loc;
        private readonly string _connectionstring;

        public TicketBookingController(ITicketBooking Results,ITicketLocations location, IConfiguration configuration)
        {
            _Result =Results;
            _loc = location;
            _connectionstring = configuration.GetConnectionString("DbConnection");
        }
        public ActionResult Index()
        {
            var ticket = _Result.ReadSP();
            return View("View" , ticket);
        }

        // GET: TicketBookingController1/Details/5
        public ActionResult Details(int id)
        {
            var tkt = _Result.ReadbyIDSP(id);
            tkt.Locations = _loc.GetAllLocations();
            return View("Details",tkt);
        }

        // GET: TicketBookingController1/Create
        public ActionResult Create()
        {
            var final = new TicketModel();
            final.Locations = _loc.GetAllLocations();
            return View("AddDetails", final);
        }

        // POST: TicketBookingController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(TicketModel final)
        {
            try
            {
                _Result.InsertSP(final);
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
            var tkt = _Result.ReadbyIDSP(id);
            tkt.Locations = _loc.GetAllLocations();
            return View("Edit",tkt);
        }

        // POST: TicketBookingController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,TicketModel tkt)
        {
            try
            {
                _Result.UpdateSP(id, tkt);
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
            var tkt = _Result.ReadbyIDSP(id);
            return View("Delete",tkt);
        }

        // POST: TicketBookingController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TicketModel tkt)
        {
            try
            {
                _Result.DeleteSP(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
