using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_vjp_pr0.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(Session["tk"] == null)
            {
                return RedirectToAction("Login", "Acounts");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            if (Session["tk"] == null)
            {
                return RedirectToAction("Login", "Acounts");
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            if (Session["tk"] == null)
            {
                return RedirectToAction("Login", "Acounts");
            }
            return View();
        }
    }
}