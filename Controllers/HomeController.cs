using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPHE.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "PHE";
            ViewBag.ApplicationName = "PHE Cursos Online";

            return View();
        }
    }
}
