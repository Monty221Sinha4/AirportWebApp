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
    public class TerminalsController : Controller
    {
        private AirportDB db = new AirportDB();

        // GET: Terminals
        public ActionResult Index()
        {
            return View(db.Terminals1.ToList());
        }

        // GET: Terminals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terminals terminals = db.Terminals1.Find(id);
            if (terminals == null)
            {
                return HttpNotFound();
            }
            return View(terminals);
        }

        // GET: Terminals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Terminals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TermID,Terminal")] Terminals terminals)
        {
            if (ModelState.IsValid)
            {
                db.Terminals1.Add(terminals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(terminals);
        }

        // GET: Terminals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terminals terminals = db.Terminals1.Find(id);
            if (terminals == null)
            {
                return HttpNotFound();
            }
            return View(terminals);
        }

        // POST: Terminals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TermID,Terminal")] Terminals terminals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(terminals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(terminals);
        }

        // GET: Terminals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terminals terminals = db.Terminals1.Find(id);
            if (terminals == null)
            {
                return HttpNotFound();
            }
            return View(terminals);
        }

        // POST: Terminals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Terminals terminals = db.Terminals1.Find(id);
            db.Terminals1.Remove(terminals);
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
