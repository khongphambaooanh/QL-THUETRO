using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTHUETRO_BAOOANH.Models;
using System.Security.Cryptography;


namespace QLTHUETRO_BAOOANH.Controllers
{
    public class HomeController : Controller
    {
        private QL_THUETRO_BOEntities11 _db = new QL_THUETRO_BOEntities11();

        public ActionResult Index()
        {
            if (Session["idUser"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}