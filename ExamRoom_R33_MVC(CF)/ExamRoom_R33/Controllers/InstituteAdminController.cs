using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamRoom_R33.Models;

namespace ExamRoom_R33.Controllers
{
    public class InstituteAdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InstituteAdmin
        public ActionResult Index()
        {
            return View(db.InstituteAdmins.ToList());
        }

        // GET: InstituteAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstituteAdmin instituteAdmin = db.InstituteAdmins.Find(id);
            if (instituteAdmin == null)
            {
                return HttpNotFound();
            }
            return View(instituteAdmin);
        }

        // GET: InstituteAdmin/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: InstituteAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstituteAdminID,InsAdminName,InstituteName")] InstituteAdmin instituteAdmin)
        {
            if (ModelState.IsValid)
            {
                db.InstituteAdmins.Add(instituteAdmin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return PartialView(instituteAdmin);
        }

        // GET: InstituteAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstituteAdmin instituteAdmin = db.InstituteAdmins.Find(id);
            if (instituteAdmin == null)
            {
                return HttpNotFound();
            }
            return View(instituteAdmin);
        }

        // POST: InstituteAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstituteAdminID,InsAdminName,InstituteName")] InstituteAdmin instituteAdmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instituteAdmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instituteAdmin);
        }

        // GET: InstituteAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstituteAdmin instituteAdmin = db.InstituteAdmins.Find(id);
            if (instituteAdmin == null)
            {
                return HttpNotFound();
            }
            return View(instituteAdmin);
        }

        // POST: InstituteAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InstituteAdmin instituteAdmin = db.InstituteAdmins.Find(id);
            db.InstituteAdmins.Remove(instituteAdmin);
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
