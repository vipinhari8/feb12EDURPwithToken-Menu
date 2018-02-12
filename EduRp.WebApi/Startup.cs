using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(EduRp.WebApi.Startup))]

namespace EduRp.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
            app.UseCors(CorsOptions.AllowAll);
            ConfigureAuth(app);
        }
    }
}
