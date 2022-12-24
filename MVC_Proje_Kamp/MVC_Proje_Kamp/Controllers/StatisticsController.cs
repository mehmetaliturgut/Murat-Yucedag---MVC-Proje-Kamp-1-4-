using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrete;

namespace MVC_Proje_Kamp.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context c = new Context();
        public ActionResult Index()
        {
            var value1 = c.Categories.Count().ToString();
            ViewBag.v1 = value1;

            var value2 = c.Headings.Count(x => x.HeadingName == "Yazılım").ToString();
            ViewBag.v2 = value2;

            var value3 = (from x in c.Writers select x.WriterName.IndexOf("a")).Distinct().Count().ToString();
            ViewBag.v3 = value3;

            var value4 = c.Categories.Where(u => u.CategoryID == (c.Headings.GroupBy(x => x.CategoryID)
            .OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.CategoryName).FirstOrDefault();
            ViewBag.v4 = value4;

            var value5 = c.Categories.Count(x => x.CategoryStatus == true) - c.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.v5 = value5;
            return View();
        }
    }
}