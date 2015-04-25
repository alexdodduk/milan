using System.Security.Claims;

namespace Alix_Milan
{
    public class AppUserPrincipal : ClaimsPrincipal
    {
        public AppUserPrincipal(ClaimsPrincipal principal, string name)
            : base(principal)
        {
            this.UserName = name;
        }

        public string UserName { get; set; }
    }
}