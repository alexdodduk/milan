using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Alix_Milan.Models;

namespace Alix_Milan
{
    public abstract class AppViewPage<TModel> : WebViewPage<TModel>
    {
        protected AppUserPrincipal CurrentUser
        {
            get
            {
                return new AppUserPrincipal(this.User as ClaimsPrincipal, this.User.Identity.Name);
            }
        }

        protected override void InitializePage()
        {
            SetSocialMediaSettings();
            base.InitializePage();
        }

        private void SetSocialMediaSettings()
        {
            var settings = SocialMediaSettings.GetSettings();

            if (settings != null)
            {
                this.ViewBag.FacebookUrl = settings.FacebookUrl;
                this.ViewBag.TwitterUrl = settings.TwitterUrl;
            }
        }
    }
}