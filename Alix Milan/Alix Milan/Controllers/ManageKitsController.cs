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
    public class ManageKitsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ManageKits
        public ActionResult Index()
        {
            return View(db.Kits);
        }

        // GET: ManageKits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kit kit = db.Kits.Find(id);
            if (kit == null)
            {
                return HttpNotFound();
            }

            kit.KitItems = db.KitItems.Where(ki => ki.KitId == kit.ID);

            return View(kit);
        }

        // GET: ManageKits/Create
        public ActionResult Create()
        {
            var kitViewModel = new EnterKit
            {
                Categories = db.Categories.OrderBy(c => c.Order),
                SubCategories = db.SubCategories.OrderBy(sc => sc.Order)
            };

            return View(kitViewModel);
        }

        // POST: ManageKits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,Price,ImageFile")] EnterKit kitViewModel)
        {
            if (ModelState.IsValid == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            var kit = new Kit
            {
                Name = kitViewModel.Name,
                Description = kitViewModel.Description,
                Price = kitViewModel.Price.Value
            };

            if (kitViewModel.ImageFile != null && kitViewModel.ImageFile.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(kitViewModel.ImageFile.InputStream))
                {
                    imageData = binaryReader.ReadBytes(kitViewModel.ImageFile.ContentLength);
                }

                kit.ImageBytes = imageData;
            }

            db.Kits.Add(kit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ManageKits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Kit kit = db.Kits.Find(id);

            if (kit == null)
            {
                return HttpNotFound();
            }

            var kitViewModel = new EnterKit
            {
                ID = kit.ID,
                Name = kit.Name,
                Description = kit.Description,
                Price = kit.Price,
                Categories = db.Categories.OrderBy(c => c.Order),
                SubCategories = db.SubCategories.OrderBy(sc => sc.Order),
                ExistingImageBytes = kit.ImageBytes
            };

            return View(kitViewModel);
        }

        // POST: ManageKits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Price,ImageFile")] EnterKit kitViewModel)
        {
            var kit = db.Kits.Find(kitViewModel.ID);

            if (ModelState.IsValid == false || kit == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            kit.Name = kitViewModel.Name;
            kit.Description = kitViewModel.Description;
            kit.Price = kitViewModel.Price.Value;

            if (kitViewModel.ImageFile != null && kitViewModel.ImageFile.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(kitViewModel.ImageFile.InputStream))
                {
                    imageData = binaryReader.ReadBytes(kitViewModel.ImageFile.ContentLength);
                }

                kit.ImageBytes = imageData;
            }

            db.Entry(kit).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ManageKits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kit kit = db.Kits.Find(id);
            if (kit == null)
            {
                return HttpNotFound();
            }
            return View(kit);
        }

        // POST: ManageKits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kit kit = db.Kits.Find(id);
            db.Kits.Remove(kit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetSubCategories(string selection)
        {
            var subcategories = db.SubCategories.Where(sc => sc.CategoryId.ToString() == selection).OrderBy(sc => sc.Order).ToList();

            return Json(subcategories);
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
