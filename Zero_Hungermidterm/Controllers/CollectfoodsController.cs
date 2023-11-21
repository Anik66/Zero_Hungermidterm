using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Zero_Hungermidterm.EF;

namespace Zero_Hungermidterm.Controllers
{
    public class CollectfoodsController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: Collectfoods
        public ActionResult Index()
        {
            return View(db.Collectfoods.ToList());
        }

        // GET: Collectfoods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collectfood collectfood = db.Collectfoods.Find(id);
            if (collectfood == null)
            {
                return HttpNotFound();
            }
            return View(collectfood);
        }

        // GET: Collectfoods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Collectfoods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Request_no,Dish_name,Type,Quantity,pick_date")] Collectfood collectfood)
        {
            if (ModelState.IsValid)
            {
                db.Collectfoods.Add(collectfood);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(collectfood);
        }

        // GET: Collectfoods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collectfood collectfood = db.Collectfoods.Find(id);
            if (collectfood == null)
            {
                return HttpNotFound();
            }
            return View(collectfood);
        }

        // POST: Collectfoods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Request_no,Dish_name,Type,Quantity,pick_date")] Collectfood collectfood)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collectfood).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(collectfood);
        }

        // GET: Collectfoods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collectfood collectfood = db.Collectfoods.Find(id);
            if (collectfood == null)
            {
                return HttpNotFound();
            }
            return View(collectfood);
        }

        // POST: Collectfoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Collectfood collectfood = db.Collectfoods.Find(id);
            db.Collectfoods.Remove(collectfood);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
