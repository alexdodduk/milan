using System.Security.Claims;
using System.Web.Mvc;

namespace Alix_Milan.Controllers
{
    public class AppController : Controller
    {
        public AppUserPrincipal CurrentUser
        {
            get
            {
                return new AppUserPrincipal(base.User as ClaimsPrincipal, base.User.Identity.Name);
            }
        }
    }
}