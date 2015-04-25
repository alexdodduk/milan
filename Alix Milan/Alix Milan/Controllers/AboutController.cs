using Alix_Milan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alix_Milan.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: KitHire
        public ActionResult Index()
        {
            return View(db.Abouts.SingleOrDefault());
        }
    }
}