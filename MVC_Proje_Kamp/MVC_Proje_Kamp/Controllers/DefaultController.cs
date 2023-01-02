using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Proje_Kamp.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager hm = new HeadingManager(new EfHeadingDAL());
        ContentManager cm = new ContentManager(new EfContentDAL());

        public ActionResult Headings()
        {
            var headinglist = hm.GetList();
            return View(headinglist);
        }
        public PartialViewResult Index(int id=1)
        {
            var contentlist = cm.GetListByHeadingID(id);
            return PartialView(contentlist);
        }
    }
}