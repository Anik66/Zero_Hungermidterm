using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hungermidterm.EF;

namespace Zero_Hungermidterm.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        public ActionResult AdminList()
        {
            var db = new Entities1();
            var data = db.Admins.ToList();
            return View(data);
        }
        public ActionResult AdCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdCreate(Admin s)
        {

            var db = new Entities1();
            db.Admins.Add(s);
            db.SaveChanges();
            return RedirectToAction("AdminList");
        }
        
    }
}