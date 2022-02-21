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
    public class AirportCodesController : Controller
    {
        private AirportDB db = new AirportDB();

        // GET: AirportCodes
        public ActionResult Index()
        {
            return View(db.AirportCodes.ToList());
        }

        // GET: AirportCodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirportCode airportCode = db.AirportCodes.Find(id);
            if (airportCode == null)
            {
                return HttpNotFound();
            }
            return View(airportCode);
        }

        // GET: AirportCodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AirportCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodeID,CodeName")] AirportCode airportCode)
        {
            if (ModelState.IsValid)
            {
                db.AirportCodes.Add(airportCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(airportCode);
        }

        // GET: AirportCodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirportCode airportCode = db.AirportCodes.Find(id);
            if (airportCode == null)
            {
                return HttpNotFound();
            }
            return View(airportCode);
        }

        // POST: AirportCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodeID,CodeName")] AirportCode airportCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airportCode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(airportCode);
        }

        // GET: AirportCodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirportCode airportCode = db.AirportCodes.Find(id);
            if (airportCode == null)
            {
                return HttpNotFound();
            }
            return View(airportCode);
        }

        // POST: AirportCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AirportCode airportCode = db.AirportCodes.Find(id);
            db.AirportCodes.Remove(airportCode);
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
