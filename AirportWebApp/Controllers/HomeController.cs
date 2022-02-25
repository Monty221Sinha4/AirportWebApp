using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirportWebApp;

namespace AirportWebApp.Controllers
{
    public class HomeController : Controller
    {
        private AirportDB dB = new AirportDB();
        // GET: Home
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult TimeTable()
        {
            return View(dB.AirportTimeTables.ToList());
        }
        public ActionResult AboutUs()
        {
            return View();
        }
    }
}