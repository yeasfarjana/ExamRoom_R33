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
    public class QuestionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Question
        public ActionResult Index()
        {
            var questions = db.Questions.Include(q => q.QuestionCategory).Include(q => q.QuestionMaker);
            return View(questions.ToList());
        }

        // GET: Question/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Question/Create
        public ActionResult Create()
        {
            ViewBag.QuestionCategoryId = new SelectList(db.QuestionCategorys, "Id", "Category");
            ViewBag.QuestionMakerID = new SelectList(db.QuestionMakers, "QuestionMakerID", "QuestionMakerName");
            return View();
        }

        // POST: Question/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,QuestionCategoryId,QuestionType,Question1,QuestionMakerID,Points,IsActive")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Create","Choice");
            }

            ViewBag.QuestionCategoryId = new SelectList(db.QuestionCategorys, "Id", "Category", question.QuestionCategoryId);
            ViewBag.QuestionMakerID = new SelectList(db.QuestionMakers, "QuestionMakerID", "QuestionMakerName", question.QuestionMakerID);
            return View(question);
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionCategoryId = new SelectList(db.QuestionCategorys, "Id", "Category", question.QuestionCategoryId);
            ViewBag.QuestionMakerID = new SelectList(db.QuestionMakers, "QuestionMakerID", "QuestionMakerName", question.QuestionMakerID);
            return View(question);
        }

        // POST: Question/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,QuestionCategoryId,QuestionType,Question1,QuestionMakerID,Points,IsActive")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionCategoryId = new SelectList(db.QuestionCategorys, "Id", "Category", question.QuestionCategoryId);
            ViewBag.QuestionMakerID = new SelectList(db.QuestionMakers, "QuestionMakerID", "QuestionMakerName", question.QuestionMakerID);
            return View(question);
        }

        // GET: Question/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
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
