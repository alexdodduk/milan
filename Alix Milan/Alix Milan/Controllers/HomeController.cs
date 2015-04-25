using System.Security.Claims;
using System.Web.Mvc;

namespace Alix_Milan.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //return View();

            // redirect to Home for now
            return RedirectToAction("", "Projects");
        }
    }
}