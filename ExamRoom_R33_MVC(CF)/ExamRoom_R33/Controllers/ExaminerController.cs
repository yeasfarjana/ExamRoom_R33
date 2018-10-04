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
    public class ExaminerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Examiner
        public ActionResult Index()
        {
            var examiners = db.Examiners.Include(e => e.InstituteAdmin);
            return View(examiners.ToList());
        }

        // GET: Examiner/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examiner examiner = db.Examiners.Find(id);
            if (examiner == null)
            {
                return HttpNotFound();
            }
            return View(examiner);
        }

        // GET: Examiner/Create
        public ActionResult Create()
        {
            ViewBag.InstituteAdminID = new SelectList(db.InstituteAdmins, "InstituteAdminID", "InsAdminName");
            return PartialView();
        }

        // POST: Examiner/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExaminerID,InstituteAdminID,UserName")] Examiner examiner)
        {
            if (ModelState.IsValid)
            {
                db.Examiners.Add(examiner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstituteAdminID = new SelectList(db.InstituteAdmins, "InstituteAdminID", "InsAdminName", examiner.InstituteAdminID);
            return PartialView(examiner);
        }

        // GET: Examiner/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examiner examiner = db.Examiners.Find(id);
            if (examiner == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstituteAdminID = new SelectList(db.InstituteAdmins, "InstituteAdminID", "InsAdminName", examiner.InstituteAdminID);
            return View(examiner);
        }

        // POST: Examiner/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExaminerID,InstituteAdminID,UserName")] Examiner examiner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examiner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstituteAdminID = new SelectList(db.InstituteAdmins, "InstituteAdminID", "InsAdminName", examiner.InstituteAdminID);
            return View(examiner);
        }

        // GET: Examiner/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examiner examiner = db.Examiners.Find(id);
            if (examiner == null)
            {
                return HttpNotFound();
            }
            return View(examiner);
        }

        // POST: Examiner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Examiner examiner = db.Examiners.Find(id);
            db.Examiners.Remove(examiner);
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
