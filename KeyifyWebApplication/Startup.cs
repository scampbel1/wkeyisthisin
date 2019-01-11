using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(KeyifyRestApi.Startup))]

namespace KeyifyRestApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(WebApiConfig.Register());
        }
    }
}