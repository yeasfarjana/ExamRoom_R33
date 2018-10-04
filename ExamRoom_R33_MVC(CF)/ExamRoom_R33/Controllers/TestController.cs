using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamRoom_R33.Models;


using System.Configuration;
using System.Data.SqlClient;


namespace ExamRoom_R33.Controllers
{
    public class TestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Test
        public ActionResult Index()
        {
            return View(db.Tests.ToList());
        }

        // GET: Test/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,IsActive,DurationInMinute")] Test test)
        {

            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var connection = new SqlConnection(connectionString);


            if (ModelState.IsValid)
            {
                db.Tests.Add(test);
                db.SaveChanges();


                string queryString = "Insert into ExamAudits(TableName,ModifiedBy,Action,Date) Values(@mtablename,@modby,@uaction,@modate);";
                var command = new SqlCommand(queryString, connection);

                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@mtablename", "Test");

                if (User.Identity.Name == "")
                {
                    command.Parameters.AddWithValue("@modby", "User was Anonymous");
                }
                else
                {
                    command.Parameters.AddWithValue("@modby", User.Identity.Name);
                }
                command.Parameters.AddWithValue("@uaction", "Create");
                command.Parameters.AddWithValue("@modate", DateTime.Now);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return RedirectToAction("Index");
            }

            return View(test);
        }

        // GET: Test/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: Test/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,IsActive,DurationInMinute")] Test test)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var connection = new SqlConnection(connectionString);

            if (ModelState.IsValid)
            {
                db.Entry(test).State = EntityState.Modified;
                db.SaveChanges();

                string queryString = "Insert into ExamAudits(TableName,ModifiedBy,Action,Date) Values(@mtablename,@modby,@uaction,@modate);";
                var command = new SqlCommand(queryString, connection);

                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@mtablename", "Test");

                if (User.Identity.Name == "")
                {
                    command.Parameters.AddWithValue("@modby", "User was Anonymous");
                }
                else
                {
                    command.Parameters.AddWithValue("@modby", User.Identity.Name);
                }
                command.Parameters.AddWithValue("@uaction", "Edit");
                command.Parameters.AddWithValue("@modate", DateTime.Now);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                return RedirectToAction("Index");
            }
            return View(test);
        }

        // GET: Test/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var connection = new SqlConnection(connectionString);



            Test test = db.Tests.Find(id);
            db.Tests.Remove(test);
            db.SaveChanges();


            string queryString = "Insert into ExamAudits(TableName,ModifiedBy,Action,Date) Values(@mtablename,@modby,@uaction,@modate);";
            var command = new SqlCommand(queryString, connection);

            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@mtablename", "Test");

            if (User.Identity.Name == "")
            {
                command.Parameters.AddWithValue("@modby", "User was Anonymous");
            }
            else
            {
                command.Parameters.AddWithValue("@modby", User.Identity.Name);
            }
            command.Parameters.AddWithValue("@uaction", "Delete");
            command.Parameters.AddWithValue("@modate", DateTime.Now);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

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
