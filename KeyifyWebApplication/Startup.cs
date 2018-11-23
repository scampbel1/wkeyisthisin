using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(KeyifyWebApplication.Startup))]

namespace KeyifyWebApplication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(WebApiConfig.Register());
        }
    }
}