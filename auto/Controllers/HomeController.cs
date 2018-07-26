using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using auto.Models;

namespace auto.Controllers
{
    public class HomeController : Controller
    {
        private AutoEntities db = new AutoEntities();
        public ActionResult Index()
        {
            return View();
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

        [HttpPost]
        public JsonResult GetCountries(string Prefix)
        {

            var Countries = (from c in db.Countries
                             where c.Name.StartsWith(Prefix)
                             select new { c.Name, c.Id }).ToList();
            return Json(Countries, JsonRequestBehavior.AllowGet);
        }




    }
}