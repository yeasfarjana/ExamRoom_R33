using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamRoom_R33.Controllers
{
    public class AdminPanelController : Controller
    {
        // GET: AdminPanel
        [Authorize(Roles = "System Admin, Institute Admin, Examiner, Question Maker")]
        public ActionResult Index()
        {
            return View();
        }
        
    }
}