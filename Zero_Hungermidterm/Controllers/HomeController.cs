using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hungermidterm.EF;

namespace Zero_Hungermidterm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserLogin()
        {
            return View();
        }

        public ActionResult UserList()
        {
            var db = new Entities1();
            var data = db.Employees.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee s)
        {

            var db = new Entities1();
            db.Employees.Add(s);
            db.SaveChanges();
            return RedirectToAction("UserList");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new Entities1();
            var ex = (from d in db.Employees
                      where d.Id == id
                      select d).SingleOrDefault();
            return View(ex);
        }
        public ActionResult Edit(Employee c)
        {
            var db = new Entities1();
            var exdata = db.Employees.Find(c.Id);
            exdata.Id = c.Id;
            exdata.Email = c.Email;
            exdata.Name = c.Name;
            exdata.Phone = c.Phone;
            exdata.Password = c.Password;

            db.SaveChanges();
            return RedirectToAction("userList");

        }

        public ActionResult Delete(int id)
        {
            var db = new Entities1();
            var exdata = db.Employees.Find(id);
            db.Employees.Remove(exdata);
            db.SaveChanges();
            return RedirectToAction("UserList");
        }



    }
}