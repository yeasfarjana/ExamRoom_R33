using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ExamRoom_R33.Models;


namespace ExamRoom_R33.Controllers
{
    public class ExamAuditController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Audit
        [Authorize(Roles ="Institute Admin")]
        public ActionResult Index()
        {
            return View(db.ExamAudits.ToList());
        }
    }
}