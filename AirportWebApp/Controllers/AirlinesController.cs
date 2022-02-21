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
    public class AirlinesController : Controller
    {
        private AirportDB db = new AirportDB();

        // GET: Airlines
        public ActionResult Index()
        {
            return View(db.Airlines1.ToList());
        }

        // GET: Airlines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airlines airlines = db.Airlines1.Find(id);
            if (airlines == null)
            {
                return HttpNotFound();
            }
            return View(airlines);
        }

        // GET: Airlines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Airlines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AirlineID,Airline")] Airlines airlines)
        {
            if (ModelState.IsValid)
            {
                db.Airlines1.Add(airlines);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(airlines);
        }

        // GET: Airlines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airlines airlines = db.Airlines1.Find(id);
            if (airlines == null)
            {
                return HttpNotFound();
            }
            return View(airlines);
        }

        // POST: Airlines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AirlineID,Airline")] Airlines airlines)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airlines).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(airlines);
        }

        // GET: Airlines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airlines airlines = db.Airlines1.Find(id);
            if (airlines == null)
            {
                return HttpNotFound();
            }
            return View(airlines);
        }

        // POST: Airlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Airlines airlines = db.Airlines1.Find(id);
            db.Airlines1.Remove(airlines);
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
