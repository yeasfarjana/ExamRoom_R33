using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamRoom_R33.Models;
using System.Web.Helpers;

namespace ExamRoom_R33.Controllers
{
    public class FeedbackController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Feedback
        public ActionResult Index()
        {
            return View(db.Feedbacks.ToList());
        }

        //Get FeadbackPage
        public ActionResult FeadbackPage()
        {
            return View();
        }

        //Post FeadbackPage
        [HttpPost]
        public ActionResult FeadbackPage(Feedback fedback)
        {
            if (ModelState.IsValid)
            {
                // Here, this mail ID used to receive the all mails from the clients
                WebMail.Send("examroomr33@gmail.com"
                    , fedback.FullName + " is feedback to your siteas as " + fedback.FeedbackScale
                    , fedback.FullName + "'s Cell Phone Number : " + fedback.PhoneNumber + "<br/><br/> & " + fedback.FullName + "'s Email Address : " + fedback.Email + "<br/><br/> Message: " + fedback.Message
                    , null
                    , null
                    , null
                    , true
                    , null
                    , null
                    , null
                    , null
                    , null
                    , fedback.Email);

                //return RedirectToAction("ThankYouPage");
                if (ModelState.IsValid)
                {
                    db.Feedbacks.Add(fedback);
                    db.SaveChanges();
                    return RedirectToAction("ThankYouPage");
                }

            }
            return View();
        }

        public ActionResult ThankYouPage()
        {
            return View();
        }

        // GET: FeedBack/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }
    }
}