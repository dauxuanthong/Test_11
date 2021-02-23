using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMS_Test_12.Models;

namespace CMS_Test_12.Controllers
{
    public class Assignment1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Assignment1
        public ActionResult Index()
        {
            var assignment1s = db.Assignment1s.Include(a => a.CoordinatorToFaculty);
            return View(assignment1s.ToList());
        }

        // GET: Assignment1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment1 assignment1 = db.Assignment1s.Find(id);
            if (assignment1 == null)
            {
                return HttpNotFound();
            }
            return View(assignment1);
        }

        // GET: Assignment1/Create
        public ActionResult Create()
        {
            ViewBag.CoordinatorToFacultyId = new SelectList(db.CoordinatorToFacultys, "Id", "Id");
            return View();
        }

        // POST: Assignment1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CoordinatorToFacultyId,StartDate,EndDate")] Assignment1 assignment1)
        {
            if (ModelState.IsValid)
            {
                db.Assignment1s.Add(assignment1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CoordinatorToFacultyId = new SelectList(db.CoordinatorToFacultys, "Id", "Id", assignment1.CoordinatorToFacultyId);
            return View(assignment1);
        }

        // GET: Assignment1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment1 assignment1 = db.Assignment1s.Find(id);
            if (assignment1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.CoordinatorToFacultyId = new SelectList(db.CoordinatorToFacultys, "Id", "Id", assignment1.CoordinatorToFacultyId);
            return View(assignment1);
        }

        // POST: Assignment1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CoordinatorToFacultyId,StartDate,EndDate")] Assignment1 assignment1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignment1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CoordinatorToFacultyId = new SelectList(db.CoordinatorToFacultys, "Id", "Id", assignment1.CoordinatorToFacultyId);
            return View(assignment1);
        }

        // GET: Assignment1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment1 assignment1 = db.Assignment1s.Find(id);
            if (assignment1 == null)
            {
                return HttpNotFound();
            }
            return View(assignment1);
        }

        // POST: Assignment1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assignment1 assignment1 = db.Assignment1s.Find(id);
            db.Assignment1s.Remove(assignment1);
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
