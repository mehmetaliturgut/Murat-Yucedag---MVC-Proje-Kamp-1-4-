using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Proje_Kamp.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager adm = new AdminManager(new EfAdminDAL());
        public ActionResult Index()
        {
            var adminvalues = adm.GetList();
            return View(adminvalues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            string encpassword = Encryption.Encrypt(p.AdminPassword);
            p.AdminPassword = encpassword;
            adm.AdminAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminvalue = adm.GetByID(id);
            return View(adminvalue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            adm.AdminUpdate(p);
            return RedirectToAction("Index");
        }
    }
}