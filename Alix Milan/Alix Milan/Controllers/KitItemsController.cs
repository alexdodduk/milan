using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Alix_Milan;
using Alix_Milan.Models;

namespace Alix_Milan.Controllers
{
    public class KitItemsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: KitItems
        public ActionResult Index()
        {
            return View(db.KitItems.ToList());
        }

        // GET: KitItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KitItem kitItem = db.KitItems.Find(id);
            if (kitItem == null)
            {
                return HttpNotFound();
            }
            return View(kitItem);
        }

        // GET: KitItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KitItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description")] KitItem kitItem)
        {
            if (ModelState.IsValid)
            {
                db.KitItems.Add(kitItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kitItem);
        }

        // GET: KitItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KitItem kitItem = db.KitItems.Find(id);
            if (kitItem == null)
            {
                return HttpNotFound();
            }
            return View(kitItem);
        }

        // POST: KitItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description")] KitItem kitItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kitItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kitItem);
        }

        // GET: KitItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KitItem kitItem = db.KitItems.Find(id);
            if (kitItem == null)
            {
                return HttpNotFound();
            }
            return View(kitItem);
        }

        // POST: KitItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KitItem kitItem = db.KitItems.Find(id);
            db.KitItems.Remove(kitItem);
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
