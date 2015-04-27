using Alix_Milan.Models;
using Alix_Milan.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Alix_Milan.Controllers
{
    [AllowAnonymous]
    public class KitHireController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: KitHire
        public ActionResult Index()
        {
            return View(new KitHireModel
                {
                     Categories = db.Categories.OrderBy(c => c.Order),
                     Kits = db.Kits.OrderBy(k => k.Order)
                });
        }

        public ActionResult Kit(string kitName)
        {
            var kit = db.Kits.SingleOrDefault(k => k.Name == kitName);

            if (kit == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var kitModel = new KitModel
            {
                ID = kit.ID,
                Name = kit.Name,
                Description = kit.Description,
                Price = kit.Price,
                KitItems = db.KitItems.Where(ki => ki.KitId == kit.ID),
                ImageBytes = kit.ImageBytes

            };

            return View(kitModel);
        }

        public ActionResult Category(string categoryName)
        {
            var category = db.Categories.SingleOrDefault(c => c.Name == categoryName);

            if (category == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var categoryId = category.ID;
            var categoryModel = new KitHireCategoryModel
            {
                Name = category.Name,
                SubcategoryKitItems = GetSubcategoryKitItems(categoryId),
                MiscKitItems = GetMiscKitItems(categoryId),
                ImageBytes = category.ImageBytes
            };

            return View(categoryModel);
        }

        public ActionResult KitItem(string kitItemName)
        {
            var kitItem = db.KitItems.SingleOrDefault(c => c.Name == kitItemName);

            if (kitItem == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var kitItemModel = new KitItemModel
            {
                Name = kitItem.Name,
                Description = kitItem.Description,
                Price = kitItem.Price,
                ImageBytes = kitItem.ImageBytes
            };

            return View(kitItemModel);
        }

        private Dictionary<SubCategory, IEnumerable<KitItem>> GetSubcategoryKitItems(int categoryId)
        {
            var subcategoryKitItemsDictionary = new Dictionary<SubCategory, IEnumerable<KitItem>>();

            foreach (var subcategory in db.SubCategories.Where(sc => sc.CategoryId == categoryId).OrderBy(c => c.Order).ToList())
            {
                subcategoryKitItemsDictionary.Add(subcategory, db.KitItems.Where(ki => ki.SubCategoryId == subcategory.ID));
            }

            return subcategoryKitItemsDictionary;
        }

        private IEnumerable<KitItem> GetMiscKitItems(int categoryId)
        {
            return db.KitItems.Where(ki => ki.CategoryId == categoryId).Where(ki => ki.SubCategoryId.HasValue == false);
        }
    }
}