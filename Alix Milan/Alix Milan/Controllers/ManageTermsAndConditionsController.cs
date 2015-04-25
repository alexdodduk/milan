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
    public class ManageTermsAndConditionsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ManageTermsAndConditions
        public ActionResult Index()
        {
            var terms = db.TermsAndConditionses.ToList();

            foreach (var term in terms)
            {
                var body = term.Body;

                if (body.Length > 20)
                {
                    term.Body = body.Remove(19) + "...";
                }
            }
            return View(terms);
        }

        // GET: ManageTermsAndConditions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TermsAndConditions termsAndConditions = db.TermsAndConditionses.Find(id);
            if (termsAndConditions == null)
            {
                return HttpNotFound();
            }
            return View(termsAndConditions);
        }

        // GET: ManageTermsAndConditions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageTermsAndConditions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Body")] TermsAndConditions termsAndConditions)
        {
            if (ModelState.IsValid)
            {
                db.TermsAndConditionses.Add(termsAndConditions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(termsAndConditions);
        }

        // GET: ManageTermsAndConditions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TermsAndConditions termsAndConditions = db.TermsAndConditionses.Find(id);
            if (termsAndConditions == null)
            {
                return HttpNotFound();
            }
            return View(termsAndConditions);
        }

        // POST: ManageTermsAndConditions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Body")] TermsAndConditions termsAndConditions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(termsAndConditions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(termsAndConditions);
        }

        // GET: ManageTermsAndConditions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TermsAndConditions termsAndConditions = db.TermsAndConditionses.Find(id);
            if (termsAndConditions == null)
            {
                return HttpNotFound();
            }
            return View(termsAndConditions);
        }

        // POST: ManageTermsAndConditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TermsAndConditions termsAndConditions = db.TermsAndConditionses.Find(id);
            db.TermsAndConditionses.Remove(termsAndConditions);
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
