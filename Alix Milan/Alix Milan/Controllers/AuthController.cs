using Alix_Milan.Models;
using System.Security.Claims;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Configuration;

namespace Alix_Milan.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public AuthController()
            : this(Startup.UserManagerFactory.Invoke())
        {
        }

        public AuthController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        // GET: Auth
        [HttpGet]
        public ActionResult LogIn(string returnUrl)
        {
            var logIn = new LogInModel
            {
                ReturnUrl = returnUrl
            };

            return View(logIn);
        }

        [HttpPost]
        public async Task<ActionResult> LogIn(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (AdminUserExists() == false)
            {
                CreateAdminUser();
            }

            var user = await userManager.FindAsync(model.Username, model.Password);

            if (user != null)
            {
                await SignIn(user);

                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }

            // auth failed
            ModelState.AddModelError("", "Invalid username or password");
            return View();
        }

        private bool AdminUserExists()
        {
            using (var db = new AppDbContext())
            {
                return db.Users.AsEnumerable<AppUser>().FirstOrDefault<AppUser>(u => u.UserName == ConfigurationManager.AppSettings["DefaultUsername"]) != null;
            }
        }

        private void CreateAdminUser()
        {
            var user = new AppUser
            {
                UserName = ConfigurationManager.AppSettings["DefaultUsername"]
            };

            var result = userManager.Create(user, ConfigurationManager.AppSettings["DefaultPassword"]);

            if (result.Succeeded == false)
            {
                //var errorList = new List
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }
        }

        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("index", "home");
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }

        private IAuthenticationManager GetAuthenticationManager()
        {
            var ctx = Request.GetOwinContext();
            return ctx.Authentication;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && userManager != null)
            {
                userManager.Dispose();
            }
            base.Dispose(disposing);
        }

        private async Task SignIn(AppUser user)
        {
            var identity = await userManager.CreateIdentityAsync(
                user, DefaultAuthenticationTypes.ApplicationCookie);

            GetAuthenticationManager().SignIn(identity);
        }
    }
}