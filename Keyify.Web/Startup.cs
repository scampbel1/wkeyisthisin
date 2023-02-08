using Keyify.Models.Interfaces;
using Keyify.Models.Service;
using Keyify.Models.View_Models.Misc;
using Keyify.Service;
using Keyify.Service.Caches;
using Keyify.Service.Interfaces;
using Keyify.Web.Service;
using Keyify.Web.Service.Interfaces;
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
            services.AddSingleton(typeof(ModeDataCache), typeof(ModeDataCache));
            services.AddSingleton(typeof(IModeService), typeof(ModeService));
            services.AddSingleton(typeof(IQuickLinkService), typeof(QuickLinkService));
            services.AddSingleton(typeof(IScaleService), typeof(ScaleService));
            services.AddTransient(typeof(InstrumentViewModel), typeof(InstrumentViewModel));
            services.AddTransient(typeof(IScalesGroupingService), typeof(ScalesGroupingService));
            services.AddSingleton(typeof(IChordTemplateService), typeof(ChordTemplateService));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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