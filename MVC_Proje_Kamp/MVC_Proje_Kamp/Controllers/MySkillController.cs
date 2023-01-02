using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Proje_Kamp.Controllers
{
    //[AllowAnonymous]
    public class MySkillController : Controller
    {
        // GET: MySkill
        MySkillManager msm = new MySkillManager(new EfMySkillDAL());
        public ActionResult Index()
        {
            var skill = msm.GetList();
            return View(skill);
        }
        public ActionResult ListSkill()
        {
            var skilllist =msm.GetList();
            return View(skilllist);
        }
        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            var skillvalue = msm.GetByID(id);
            return View(skillvalue);
        }
        [HttpPost]
        public ActionResult EditSkill(MySkill skill)
        {
            msm.SkillUpdate(skill);
            return RedirectToAction("ListSkill");
        }

    }
}