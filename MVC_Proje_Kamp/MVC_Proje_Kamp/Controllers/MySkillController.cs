using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Proje_Kamp.Controllers
{
    public class MySkillController : Controller
    {
        // GET: MySkill
        MySkillManager msm = new MySkillManager(new EfMySkillDAL());
        public ActionResult Index()
        {
            var skill = msm.GetList();
            return View(skill);
        }
    }
}