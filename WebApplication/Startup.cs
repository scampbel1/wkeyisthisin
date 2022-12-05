using Keyify.Models.Interfaces;
using Keyify.Models.Service;
using Keyify.Models.View_Models.Misc;
using Keyify.Service.Interface;
using KeyifyWebClient.Models.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddSingleton(typeof(KeyifyClassLibrary.Core.Domain.ModeDefinitionService), typeof(KeyifyClassLibrary.Core.Domain.ModeDefinitionService));
            services.AddSingleton(typeof(IModeService), typeof(Models.Service.ModeService));
            services.AddSingleton(typeof(IScaleService), typeof(ScaleService));
            services.AddTransient(typeof(InstrumentViewModel), typeof(InstrumentViewModel));
            services.AddTransient(typeof(IScalesGroupingService), typeof(ScalesGroupingService));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //TODO: Implement error page

            //if (env.IsDevelopment())
            //{
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    app.UseHsts();
            //}

            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseForwardedHeaders();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Guitar}/{action=Index}");
            });
        }
    }
}