using Keyify.Models.Service;
using Keyify.Service;
using Keyify.Service.Interface;
using KeyifyWebClient.Models.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Keyify
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton(typeof(IModeDefinitionService), typeof(ModeDefinitionService));
            services.AddSingleton(typeof(IScaleListService), typeof(ScaleListService));
            services.AddTransient(typeof(InstrumentViewModel), typeof(InstrumentViewModel));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }


            var options = new RewriteOptions()
            .AddRedirectToProxiedHttps()
            .AddRedirect("(.*)/$", "$1");
            app.UseRewriter(options);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Guitar}/{action=Index}");
            });
        }
    }
}