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
    public class ManageKitItemsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ManageKitItems
        public ActionResult Index()
        {
            var kitItems = db.KitItems.ToList();

            foreach (var kitItem in kitItems)
            {
                kitItem.Kit = db.Kits.Find(kitItem.KitId);
                kitItem.Category = db.Categories.Find(kitItem.CategoryId);
                kitItem.SubCategory = db.SubCategories.Find(kitItem.SubCategoryId);
            }

            return View(kitItems);
        }

        // GET: ManageKitItems/Details/5
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

            kitItem.Kit = db.Kits.Find(kitItem.KitId);
            kitItem.Category = db.Categories.Find(kitItem.CategoryId);
            kitItem.SubCategory = db.SubCategories.Find(kitItem.SubCategoryId);

            return View(kitItem);
        }

        // GET: ManageKitItems/Create
        public ActionResult Create()
        {
            var kitItemViewModel = new EnterKitItem
            {
                Categories = db.Categories.OrderBy(c => c.Order),
                SubCategories = db.SubCategories.OrderBy(sc => sc.Order),
                Kits = db.Kits
            };

            return View(kitItemViewModel);
        }

        // POST: ManageKitItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,Price,Order,KitId,CategoryId,SubCategoryId,ImageFile")] EnterKitItem kitItemViewModel)
        {   
            var category = db.Categories.Find(kitItemViewModel.CategoryId);

            if (ModelState.IsValid == false || category == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }            

            var kitItem = new KitItem
            {
                Name = kitItemViewModel.Name,
                Description = kitItemViewModel.Description,
                Price = kitItemViewModel.Price.Value,
                Order = kitItemViewModel.Order,
                KitId = kitItemViewModel.KitId,
                CategoryId = kitItemViewModel.CategoryId,
                Category = category,
                SubCategoryId = kitItemViewModel.SubCategoryId,
            };

            if (kitItemViewModel.KitId != null)
            {
                kitItem.Kit = db.Kits.Find(kitItemViewModel.KitId);
            }

            if (kitItemViewModel.SubCategoryId != null)
            {
                kitItem.SubCategory = db.SubCategories.Find(kitItemViewModel.SubCategoryId);
            }

            if (kitItemViewModel.ImageFile != null && kitItemViewModel.ImageFile.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(kitItemViewModel.ImageFile.InputStream))
                {
                    imageData = binaryReader.ReadBytes(kitItemViewModel.ImageFile.ContentLength);
                }

                kitItem.ImageBytes = imageData;
            }

            db.KitItems.Add(kitItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ManageKitItems/Edit/5
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

            var kitItemViewModel = new EnterKitItem
            {
                ID = kitItem.ID,
                Name = kitItem.Name,
                Description = kitItem.Description,
                Price = kitItem.Price,
                Order = kitItem.Order,
                KitId = kitItem.KitId,
                CategoryId = kitItem.CategoryId,
                SubCategoryId = kitItem.SubCategoryId,
                Kits = db.Kits,
                Categories = db.Categories.OrderBy(c => c.Order),
                SubCategories = db.SubCategories.OrderBy(sc => sc.Order),
                ExistingImageBytes = kitItem.ImageBytes
            };

            return View(kitItemViewModel);
        }

        // POST: ManageKitItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Price,Order,KitId,CategoryId,SubCategoryId,ImageFile")] EnterKitItem kitItemViewModel)
        {
            var kitItem = db.KitItems.Find(kitItemViewModel.ID);
            var category = db.Categories.Find(kitItemViewModel.CategoryId);

            if (ModelState.IsValid == false || category == null || kitItem == null)
            {
                return View(kitItem);
            }

            kitItem.Name = kitItemViewModel.Name;
            kitItem.Description = kitItemViewModel.Description;
            kitItem.Price = kitItemViewModel.Price.Value;
            kitItem.Order = kitItemViewModel.Order;
            kitItem.KitId = kitItemViewModel.KitId;
            kitItem.CategoryId = kitItemViewModel.CategoryId;
            kitItem.Category = category;
            kitItem.SubCategoryId = kitItemViewModel.SubCategoryId;

            if (kitItemViewModel.KitId != null)
            {
                kitItem.Kit = db.Kits.Find(kitItemViewModel.KitId);
            }

            if (kitItemViewModel.SubCategoryId != null)
            {
                kitItem.SubCategory = db.SubCategories.Find(kitItemViewModel.SubCategoryId);
            }

            if (kitItemViewModel.ImageFile != null && kitItemViewModel.ImageFile.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(kitItemViewModel.ImageFile.InputStream))
                {
                    imageData = binaryReader.ReadBytes(kitItemViewModel.ImageFile.ContentLength);
                }

                kitItem.ImageBytes = imageData;
            }

            db.Entry(kitItem).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ManageKitItems/Delete/5
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

        // POST: ManageKitItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KitItem kitItem = db.KitItems.Find(id);
            db.KitItems.Remove(kitItem);
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
