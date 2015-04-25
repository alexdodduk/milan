using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alix_Milan.Controllers
{
    public class DashboardController : AppController
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}