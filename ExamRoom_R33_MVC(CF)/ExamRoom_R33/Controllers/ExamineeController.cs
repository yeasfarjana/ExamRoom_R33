using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamRoom_R33.Models;

using Microsoft.Reporting.WebForms;
using System.IO;

namespace ExamRoom_R33.Controllers
{
    public class ExamineeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Examinee
        public ActionResult Index()
        {
            return View(db.Examinees.ToList());
        }


        public ActionResult ExamineeReport()
        {

            var v = db.Examinees.ToList();
            return View(v);

        }



        public ActionResult Report(string id)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Report"), "ExamineeReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");
            }
            List<Examinee> cm = new List<Examinee>();


            cm = db.Examinees.ToList();

            ReportDataSource rd = new ReportDataSource("ExamineeDataSet", cm);
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;



            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
            "  <PageWidth>8.27in</PageWidth>" +
            "  <PageHeight>11.69in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>0.6in</MarginLeft>" +
            "  <MarginRight>0.6in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);
            return File(renderedBytes, mimeType);
        }

        // GET: Examinee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examinee examinee = db.Examinees.Find(id);
            if (examinee == null)
            {
                return HttpNotFound();
            }
            return View(examinee);
        }

        // GET: Examinee/Create

        public JsonResult IsEmailAddressExists(string email)
        {
            return Json(!db.Examinees.Any(x => x.Email == email), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: Examinee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExamineeID,Name,EntryDate,DOB,Address,Phone,Email")] Examinee examinee)
        {
            if (ModelState.IsValid)
            {
                db.Examinees.Add(examinee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(examinee);
        }

        // GET: Examinee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examinee examinee = db.Examinees.Find(id);
            if (examinee == null)
            {
                return HttpNotFound();
            }
            return View(examinee);
        }

        // POST: Examinee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExamineeID,Name,EntryDate,DOB,Address,Phone,Email")] Examinee examinee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examinee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(examinee);
        }

        // GET: Examinee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examinee examinee = db.Examinees.Find(id);
            if (examinee == null)
            {
                return HttpNotFound();
            }
            return View(examinee);
        }

        // POST: Examinee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Examinee examinee = db.Examinees.Find(id);
            db.Examinees.Remove(examinee);
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
