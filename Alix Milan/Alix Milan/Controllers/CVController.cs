using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alix_Milan.Controllers
{
    public class CVController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: CV
        [AllowAnonymous]
        public ActionResult Index()
        {
            var cv = db.CVs.SingleOrDefault();

            if (cv == null)
            {
                return HttpNotFound();
            }

            MemoryStream output = new MemoryStream();
            output.Write(cv.File, 0, cv.File.Length);
            output.Position = 0;

            HttpContext.Response.AddHeader("content-disposition", "inline; filename=CV.pdf");

            // Return the output stream
            return File(output, "application/pdf");
        }
    }
}