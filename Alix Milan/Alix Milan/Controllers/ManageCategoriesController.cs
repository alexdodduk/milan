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
using Alix_Milan.ViewModels;
using System.IO;

namespace Alix_Milan.Controllers
{
    public class ManageCategoriesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ManageCategories
        public ActionResult Index()
        {
            return View(db.Categories.OrderBy(c => c.Order).ToList());
        }

        // GET: ManageCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: ManageCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Order,ImageFile")] EnterCategory categoryViewModel)
        {
            if (ModelState.IsValid == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            var category = new Category
            {
                Name = categoryViewModel.Name,
                Order = categoryViewModel.Order
            };

            if (categoryViewModel.ImageFile != null && categoryViewModel.ImageFile.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(categoryViewModel.ImageFile.InputStream))
                {
                    imageData = binaryReader.ReadBytes(categoryViewModel.ImageFile.ContentLength);
                }

                category.ImageBytes = imageData;
            }

            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ManageCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            var categoryViewModel = new EnterCategory
            {
                ID = category.ID,
                Name = category.Name,
                Order = category.Order,
                ExistingImageBytes = category.ImageBytes
            };

            return View(categoryViewModel);
        }

        // POST: ManageCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Order,ImageFile")] EnterCategory categoryViewModel)
        {
            var category = db.Categories.Find(categoryViewModel.ID);

            if (ModelState.IsValid == false || category == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            category.Name = categoryViewModel.Name;
            category.Order = categoryViewModel.Order;

            if (categoryViewModel.ImageFile != null && categoryViewModel.ImageFile.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(categoryViewModel.ImageFile.InputStream))
                {
                    imageData = binaryReader.ReadBytes(categoryViewModel.ImageFile.ContentLength);
                }

                category.ImageBytes = imageData;
            }

            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ManageCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: ManageCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
