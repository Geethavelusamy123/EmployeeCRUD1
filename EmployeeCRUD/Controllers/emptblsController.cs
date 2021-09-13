using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeCRUD.Models;

namespace EmployeeCRUD.Controllers
{
    public class emptblsController : Controller
    {
        private EmpEntities db = new EmpEntities();

        // GET: emptbls
        public ActionResult Index()
        {
            return View(db.emptbls.ToList());
        }

        // GET: emptbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emptbl emptbl = db.emptbls.Find(id);
            if (emptbl == null)
            {
                return HttpNotFound();
            }
            return View(emptbl);
        }

        // GET: emptbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: emptbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,EmployeeName,Desigination,Salary,ContactNumber")] emptbl emptbl)
        {
            if (ModelState.IsValid)
            {
                db.emptbls.Add(emptbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emptbl);
        }

        // GET: emptbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emptbl emptbl = db.emptbls.Find(id);
            if (emptbl == null)
            {
                return HttpNotFound();
            }
            return View(emptbl);
        }

        // POST: emptbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,EmployeeName,Desigination,Salary,ContactNumber")] emptbl emptbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emptbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emptbl);
        }

        // GET: emptbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emptbl emptbl = db.emptbls.Find(id);
            if (emptbl == null)
            {
                return HttpNotFound();
            }
            return View(emptbl);
        }

        // POST: emptbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            emptbl emptbl = db.emptbls.Find(id);
            db.emptbls.Remove(emptbl);
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
