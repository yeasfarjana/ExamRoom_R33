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
    public class QuestionMakerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: QuestionMaker
        public ActionResult Index()
        {
            return View(db.QuestionMakers.ToList());
        }

        // GET: QuestionMaker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionMaker questionMaker = db.QuestionMakers.Find(id);
            if (questionMaker == null)
            {
                return HttpNotFound();
            }
            return View(questionMaker);
        }

        // GET: QuestionMaker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuestionMaker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuestionMakerID,QuestionMakerName")] QuestionMaker questionMaker)
        {
            if (ModelState.IsValid)
            {
                db.QuestionMakers.Add(questionMaker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(questionMaker);
        }

        // GET: QuestionMaker/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionMaker questionMaker = db.QuestionMakers.Find(id);
            if (questionMaker == null)
            {
                return HttpNotFound();
            }
            return View(questionMaker);
        }

        // POST: QuestionMaker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuestionMakerID,QuestionMakerName")] QuestionMaker questionMaker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionMaker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(questionMaker);
        }

        // GET: QuestionMaker/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionMaker questionMaker = db.QuestionMakers.Find(id);
            if (questionMaker == null)
            {
                return HttpNotFound();
            }
            return View(questionMaker);
        }

        // POST: QuestionMaker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionMaker questionMaker = db.QuestionMakers.Find(id);
            db.QuestionMakers.Remove(questionMaker);
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
