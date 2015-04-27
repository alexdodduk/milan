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
    public class ManageSocialMediaSettingsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ManageSocialMediaSettings
        public ActionResult Index()
        {
            return View(db.SocialMediaSettingses.ToList());
        }

        // GET: ManageSocialMediaSettings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMediaSettings socialMediaSettings = db.SocialMediaSettingses.Find(id);
            if (socialMediaSettings == null)
            {
                return HttpNotFound();
            }
            return View(socialMediaSettings);
        }

        // GET: ManageSocialMediaSettings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageSocialMediaSettings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FacebookUrl,TwitterUrl")] SocialMediaSettings socialMediaSettings)
        {
            if (ModelState.IsValid)
            {
                db.SocialMediaSettingses.Add(socialMediaSettings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(socialMediaSettings);
        }

        // GET: ManageSocialMediaSettings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMediaSettings socialMediaSettings = db.SocialMediaSettingses.Find(id);
            if (socialMediaSettings == null)
            {
                return HttpNotFound();
            }
            return View(socialMediaSettings);
        }

        // POST: ManageSocialMediaSettings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FacebookUrl,TwitterUrl")] SocialMediaSettings socialMediaSettings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialMediaSettings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socialMediaSettings);
        }

        // GET: ManageSocialMediaSettings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMediaSettings socialMediaSettings = db.SocialMediaSettingses.Find(id);
            if (socialMediaSettings == null)
            {
                return HttpNotFound();
            }
            return View(socialMediaSettings);
        }

        // POST: ManageSocialMediaSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SocialMediaSettings socialMediaSettings = db.SocialMediaSettingses.Find(id);
            db.SocialMediaSettingses.Remove(socialMediaSettings);
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
