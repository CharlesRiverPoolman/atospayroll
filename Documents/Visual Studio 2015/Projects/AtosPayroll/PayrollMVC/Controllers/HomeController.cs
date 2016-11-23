using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayrollMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Atos - Your Trusted Partner in Your Digital Journey.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Atos contact page.";

            return View();
        }
    }
}