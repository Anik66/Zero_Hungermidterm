using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hungermidterm.EF;
using Zero_Hungermidterm.Models;

namespace Zero_Hungermidterm.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        
        [HttpGet]
        public ActionResult Restlogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Restlogin(restaurantDTO c)
        {
            var db = new Entities1();
            var user = (from n in db.restaurants
                        where n.Resname.Equals(c.Resname) && n.Email.Equals(c.Email)
                        select n).SingleOrDefault();
            if (user != null)
            {
                
                return RedirectToAction("Create", "Collectfoods");
            }
            else
            {
                TempData["Msg"] = "Username or Email Invalide";
            }
            return View();
        }
        [HttpGet]
        public ActionResult Emplogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Emplogin(EmployeeDTO c)
        {
            var db = new Entities1();
            var user = (from n in db.Employees
                        where n.Name.Equals(c.Name) && n.Password.Equals(c.Password)
                        select n).SingleOrDefault();
            if (user != null)
            {

                return RedirectToAction("Index", "Collectfoods");
            }
            else
            {
                TempData["Msg"] = "Username or password Invalide";
            }
            return View();
        }
        public ActionResult AdLogin(AdminDTO c)
        {
            var db = new Entities1();
            var user = (from n in db.Admins
                        where n.Name.Equals(c.Name) && n.password.Equals(c. Password)
                        select n).SingleOrDefault();
            if (user != null)
            {

                return RedirectToAction("UserList", "Home");
                
            }
            else
            {
                TempData["Msg"] = "Username or password Invalide";
            }
            return View();
        }
    }
}