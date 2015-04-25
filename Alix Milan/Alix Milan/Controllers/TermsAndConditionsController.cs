using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alix_Milan.Controllers
{
    [AllowAnonymous]
    public class TermsAndConditionsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: TermsAndConditions
        public ActionResult Index()
        {
            var termsAndConditions = db.TermsAndConditionses.SingleOrDefault();
            
            return View(termsAndConditions);
        }
    }
}