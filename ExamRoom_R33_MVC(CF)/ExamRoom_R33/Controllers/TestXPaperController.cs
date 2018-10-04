using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamRoom_R33.Models;
using Rotativa;


using System.Configuration;
using System.Data.SqlClient;

namespace ExamRoom_R33.Controllers
{
    public class TestXPaperController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TestXPaper
        public ActionResult Index()
        {


            var examineeMarks = db.TestXPapers.Sum(x => x.MarkScored);

            ViewBag.ExamineeMarks = Convert.ToDouble(examineeMarks);

            ViewBag.totalMarksOfAllQ = db.Questions.Sum(x => x.Points);

            ViewBag.TotalQuestion = db.Questions.Sum(x => x.QuestionCategoryId);


            ViewBag.PassingMarks = db.Questions.Sum(x => x.Points) * 0.7;

            if (ViewBag.ExamineeMarks >= ViewBag.PassingMarks)
            {
                ViewBag.Status = "Passed";
            }
            else
            {
                ViewBag.Status = "Failed";
            }


            return View();
        }

        public ActionResult Print()
        {
            var p = new ActionAsPdf("Index");
            return p;
        }

        // GET: TestXPaper/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestXPaper testXPaper = db.TestXPapers.Find(id);
            if (testXPaper == null)
            {
                return HttpNotFound();
            }
            return View(testXPaper);
        }

        // GET: TestXPaper/Create
        public ActionResult Create()
        {
            ViewBag.ChoiceId = new SelectList(db.Choices, "Id", "Label");
            ViewBag.RegistrationId = new SelectList(db.Registrations, "Id", "Id");
            return View();
        }

        // POST: TestXPaper/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegistrationId,TextXQuestionId,ChoiceId,Answer,MarkScored")] TestXPaper testXPaper)
        {
            if (ModelState.IsValid)
            {
                db.TestXPapers.Add(testXPaper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChoiceId = new SelectList(db.Choices, "Id", "Label", testXPaper.ChoiceId);
            ViewBag.RegistrationId = new SelectList(db.Registrations, "Id", "Id", testXPaper.RegistrationId);
            return View(testXPaper);
        }

        // GET: TestXPaper/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestXPaper testXPaper = db.TestXPapers.Find(id);
            if (testXPaper == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChoiceId = new SelectList(db.Choices, "Id", "Label", testXPaper.ChoiceId);
            ViewBag.RegistrationId = new SelectList(db.Registrations, "Id", "Id", testXPaper.RegistrationId);
            return View(testXPaper);
        }

        // POST: TestXPaper/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegistrationId,TextXQuestionId,ChoiceId,Answer,MarkScored")] TestXPaper testXPaper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testXPaper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChoiceId = new SelectList(db.Choices, "Id", "Label", testXPaper.ChoiceId);
            ViewBag.RegistrationId = new SelectList(db.Registrations, "Id", "Id", testXPaper.RegistrationId);
            return View(testXPaper);
        }

        // GET: TestXPaper/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestXPaper testXPaper = db.TestXPapers.Find(id);
            if (testXPaper == null)
            {
                return HttpNotFound();
            }
            return View(testXPaper);
        }

        // POST: TestXPaper/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestXPaper testXPaper = db.TestXPapers.Find(id);
            db.TestXPapers.Remove(testXPaper);
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
