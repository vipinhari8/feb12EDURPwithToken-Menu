using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using EduRp.WebApi.Providers;
using EduRp.WebApi.Models;

namespace EduRp.WebApi
{
    public partial class Startup
    {
            public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

            static Startup()
            {
                OAuthOptions = new OAuthAuthorizationServerOptions
                {
                    TokenEndpointPath = new PathString("/token"),
                    Provider = new ApplicationOAuthProvider(),
                    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                    AllowInsecureHttp = true
                };
            }
            public void ConfigureAuth(IAppBuilder app)
            {
               
                app.UseOAuthBearerTokens(OAuthOptions);
            }

    }
}
