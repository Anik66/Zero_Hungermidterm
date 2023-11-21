using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hungermidterm.EF;

namespace Zero_Hungermidterm.Controllers
{
    public class restaurantController : Controller
    {
        // GET: restaurant
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Reslist(restaurant s)
        {
            var db = new Entities1();
            var data = db.restaurants.ToList();
            return View(data);
        }
        public ActionResult Rcreate()
        {
            return View();
        }
        [HttpPost]


        public ActionResult Rcreate(restaurant s)
        {

            var db = new Entities1();
            db.restaurants.Add(s);
            db.SaveChanges();
            return RedirectToAction("Reslist");
        }


        
        
    }
}