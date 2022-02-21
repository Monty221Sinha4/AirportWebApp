using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirportWebApp;

namespace AirportWebApp.Controllers
{
    public class AirportTimeTablesController : Controller
    {
        private AirportDB db = new AirportDB();

        // GET: AirportTimeTables
        public ActionResult Index()
        {
            var airportTimeTables = db.AirportTimeTables.Include(a => a.Airline).Include(a => a.AirportCode).Include(a => a.City).Include(a => a.Terminal);
            return View(airportTimeTables.ToList());
        }

        // GET: AirportTimeTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirportTimeTable airportTimeTable = db.AirportTimeTables.Find(id);
            if (airportTimeTable == null)
            {
                return HttpNotFound();
            }
            return View(airportTimeTable);
        }

        // GET: AirportTimeTables/Create
        public ActionResult Create()
        {
            ViewBag.AirlineID = new SelectList(db.Airlines1, "AirlineID", "Airline");
            ViewBag.CodeID = new SelectList(db.AirportCodes, "CodeID", "CodeName");
            ViewBag.CityID = new SelectList(db.Cities1, "CityID", "City");
            ViewBag.TermID = new SelectList(db.Terminals1, "TermID", "Terminal");
            return View();
        }

        // POST: AirportTimeTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AirlineID,CodeID,CityID,TermID")] AirportTimeTable airportTimeTable)
        {
            if (ModelState.IsValid)
            {
                db.AirportTimeTables.Add(airportTimeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AirlineID = new SelectList(db.Airlines1, "AirlineID", "Airline", airportTimeTable.AirlineID);
            ViewBag.CodeID = new SelectList(db.AirportCodes, "CodeID", "CodeName", airportTimeTable.CodeID);
            ViewBag.CityID = new SelectList(db.Cities1, "CityID", "City", airportTimeTable.CityID);
            ViewBag.TermID = new SelectList(db.Terminals1, "TermID", "Terminal", airportTimeTable.TermID);
            return View(airportTimeTable);
        }

        // GET: AirportTimeTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirportTimeTable airportTimeTable = db.AirportTimeTables.Find(id);
            if (airportTimeTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.AirlineID = new SelectList(db.Airlines1, "AirlineID", "Airline", airportTimeTable.AirlineID);
            ViewBag.CodeID = new SelectList(db.AirportCodes, "CodeID", "CodeName", airportTimeTable.CodeID);
            ViewBag.CityID = new SelectList(db.Cities1, "CityID", "City", airportTimeTable.CityID);
            ViewBag.TermID = new SelectList(db.Terminals1, "TermID", "Terminal", airportTimeTable.TermID);
            return View(airportTimeTable);
        }

        // POST: AirportTimeTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AirlineID,CodeID,CityID,TermID")] AirportTimeTable airportTimeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airportTimeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AirlineID = new SelectList(db.Airlines1, "AirlineID", "Airline", airportTimeTable.AirlineID);
            ViewBag.CodeID = new SelectList(db.AirportCodes, "CodeID", "CodeName", airportTimeTable.CodeID);
            ViewBag.CityID = new SelectList(db.Cities1, "CityID", "City", airportTimeTable.CityID);
            ViewBag.TermID = new SelectList(db.Terminals1, "TermID", "Terminal", airportTimeTable.TermID);
            return View(airportTimeTable);
        }

        // GET: AirportTimeTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirportTimeTable airportTimeTable = db.AirportTimeTables.Find(id);
            if (airportTimeTable == null)
            {
                return HttpNotFound();
            }
            return View(airportTimeTable);
        }

        // POST: AirportTimeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AirportTimeTable airportTimeTable = db.AirportTimeTables.Find(id);
            db.AirportTimeTables.Remove(airportTimeTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
