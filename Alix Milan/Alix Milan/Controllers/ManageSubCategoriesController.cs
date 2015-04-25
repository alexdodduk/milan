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

namespace Alix_Milan.Controllers
{
    public class ManageSubCategoriesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ManageSubCategories
        public ActionResult Index()
        {
            var subcategoriesViewModel = new EnterSubCategory
            {
                CategorySubcategories = GetCategorySubcategories()
            };

            return View(subcategoriesViewModel);
        }

        private Dictionary<SubCategory, IEnumerable<KitItem>> GetSubcategoryItems()
        {
            throw new NotImplementedException();
        }

        // GET: ManageSubCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = db.SubCategories.Find(id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // GET: ManageSubCategories/Create
        public ActionResult Create()
        {
            var subCategoryViewModel = new EnterSubCategory
            {
                Categories = db.Categories.OrderBy(c => c.Order)
            };

            return View(subCategoryViewModel);
        }

        // POST: ManageSubCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Order,CategoryId")] EnterSubCategory subCategoryViewModel)
        {
            var category = db.Categories.Find(subCategoryViewModel.CategoryId);

            if (ModelState.IsValid == false || category == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            var subCategory = new SubCategory
            {
                CategoryId = category.ID,
                Name = subCategoryViewModel.Name,
                Order = subCategoryViewModel.Order
            };

            db.SubCategories.Add(subCategory);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: ManageSubCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = db.SubCategories.Find(id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }

            var subCategoryViewModel = new EnterSubCategory
            {
                ID = subCategory.ID,
                CategoryId = subCategory.Category.ID,
                Name = subCategory.Name,
                Order = subCategory.Order,
                Categories = db.Categories.OrderBy(c => c.Order)
            };

            return View(subCategoryViewModel);
        }

        // POST: ManageSubCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Order,CategoryId")] EnterSubCategory subCategoryViewModel)
        {
            var subCategory = db.SubCategories.Find(subCategoryViewModel.ID);
            var category = db.Categories.Find(subCategoryViewModel.CategoryId);

            if (ModelState.IsValid == false || category == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            subCategory.CategoryId = subCategoryViewModel.CategoryId;
            subCategory.Name = subCategoryViewModel.Name;
            subCategory.Order = subCategoryViewModel.Order;
            subCategory.Category = category;

            db.Entry(subCategory).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ManageSubCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = db.SubCategories.Find(id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // POST: ManageSubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubCategory subCategory = db.SubCategories.Find(id);
            db.SubCategories.Remove(subCategory);
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

        private Dictionary<Category, IEnumerable<SubCategory>> GetCategorySubcategories()
        {
            var categorySubcategoriesDictionary = new Dictionary<Category, IEnumerable<SubCategory>>();

            foreach (var category in db.Categories.OrderBy(c => c.Order))
            {
                categorySubcategoriesDictionary.Add(category, db.SubCategories.Where(sc => sc.CategoryId == category.ID));
            }

            return categorySubcategoriesDictionary;
        }
    }
}
