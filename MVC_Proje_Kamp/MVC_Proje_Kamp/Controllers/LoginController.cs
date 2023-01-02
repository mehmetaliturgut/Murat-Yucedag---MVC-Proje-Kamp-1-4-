using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Proje_Kamp.Controllers
{

    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        WriterLoginManager wlm = new WriterLoginManager(new EfWriterDAL());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            //SHA1 sha = new SHA1CryptoServiceProvider();
            //p.AdminPassword = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(p.AdminPassword)));

            //var adminuserinfo = c.AdminGet(p.AdminUserName, p.AdminPassword);

            Context c = new Context();
            string encUsername = Encryption.Encrypt(p.AdminUserName);
            string encPassword = Encryption.Encrypt(p.AdminPassword);
            var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminUserName == encUsername && x.AdminPassword == encPassword);
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");                
            }
            
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            //Context c = new Context();
            //var Writeruserinfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            //string encUsername = Encryption.Encrypt(p.WriterMail);
            string encPassword = Encryption.Encrypt(p.WriterPassword);
            var Writeruserinfo = wlm.GetWriter(p.WriterMail, encPassword);
            if (Writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(Writeruserinfo.WriterMail, false);
                Session["WriterMail"] = Writeruserinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings","Default");
        }
    }
}