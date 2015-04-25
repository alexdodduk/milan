using Microsoft.AspNet.Identity.EntityFramework;

namespace Alix_Milan
{
    public class AppUser : IdentityUser
    {
        public AppUser()
            : base()
        {
        }

        public string Name { get; set; }
    }
}