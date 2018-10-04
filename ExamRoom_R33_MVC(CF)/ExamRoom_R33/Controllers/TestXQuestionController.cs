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
    public class TestXQuestionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TestXQuestion
        public ActionResult Index()
        {
            var testXQuestions = db.TestXQuestions.Include(t => t.Question).Include(t => t.Test);
            return View(testXQuestions.ToList());
        }

        // GET: TestXQuestion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestXQuestion testXQuestion = db.TestXQuestions.Find(id);
            if (testXQuestion == null)
            {
                return HttpNotFound();
            }
            return View(testXQuestion);
        }

        // GET: TestXQuestion/Create
        public ActionResult Create()
        {
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Question1");
            ViewBag.TestId = new SelectList(db.Tests, "Id", "Name");
            return View();
        }

        // POST: TestXQuestion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TestId,QuestionId,QuestionNumber,IsActive")] TestXQuestion testXQuestion)
        {
            if (ModelState.IsValid)
            {
                db.TestXQuestions.Add(testXQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "QuestionType", testXQuestion.QuestionId);
            ViewBag.TestId = new SelectList(db.Tests, "Id", "Name", testXQuestion.TestId);
            return View(testXQuestion);
        }

        // GET: TestXQuestion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestXQuestion testXQuestion = db.TestXQuestions.Find(id);
            if (testXQuestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "QuestionType", testXQuestion.QuestionId);
            ViewBag.TestId = new SelectList(db.Tests, "Id", "Name", testXQuestion.TestId);
            return View(testXQuestion);
        }

        // POST: TestXQuestion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TestId,QuestionId,QuestionNumber,IsActive")] TestXQuestion testXQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testXQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "QuestionType", testXQuestion.QuestionId);
            ViewBag.TestId = new SelectList(db.Tests, "Id", "Name", testXQuestion.TestId);
            return View(testXQuestion);
        }

        // GET: TestXQuestion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestXQuestion testXQuestion = db.TestXQuestions.Find(id);
            if (testXQuestion == null)
            {
                return HttpNotFound();
            }
            return View(testXQuestion);
        }

        // POST: TestXQuestion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestXQuestion testXQuestion = db.TestXQuestions.Find(id);
            db.TestXQuestions.Remove(testXQuestion);
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
