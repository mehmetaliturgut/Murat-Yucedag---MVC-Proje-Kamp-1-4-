﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace MVC_Proje_Kamp.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EfHeadingDAL());
        CategoryManager cm = new CategoryManager(new EfCategoryDAL());
        WriterManager wm = new WriterManager(new EfWriterDAL());
        public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }
                                                ).ToList();
            
            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WriterName + " "+x.WriterSurName,
                                                      Value = x.WriterID.ToString()
                                                  }
                                                ).ToList();
            ViewBag.vlc = valuecategory;
            ViewBag.wlw = valuewriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate =DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }
                                                ).ToList();
            ViewBag.vlc = valuecategory;
            var HeadingValue = hm.GetByID(id);
            return View(HeadingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingvalues = hm.GetByID(id);
            if (headingvalues.HeadingStatus == true)
            {
                headingvalues.HeadingStatus = false;
                hm.HeadingDelete(headingvalues);
            }
            else
            {
                headingvalues.HeadingStatus = true;
                hm.HeadingDelete(headingvalues);
            }
            return RedirectToAction("Index");

            //var headingvalue = hm.GetByID(id);
            //hm.HeadingDelete(headingvalue);
            //return RedirectToAction("Index");
        }
    }
}