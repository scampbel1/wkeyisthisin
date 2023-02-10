using Keyify.Models.Service;
using Keyify.Service;
using Keyify.Service.Caches;
using Keyify.Service.Interfaces;
using Keyify.Web.Service;
using Keyify.Web.Service.Interfaces;
using KeyifyWebClient.Models.Instruments;
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
            services.AddSingleton(typeof(Fretboard), typeof(Fretboard));
            services.AddSingleton(typeof(ModeDataCache), typeof(ModeDataCache));
            services.AddSingleton(typeof(ChordTemplateDataCache), typeof(ChordTemplateDataCache));
            services.AddTransient(typeof(InstrumentViewModel), typeof(InstrumentViewModel));

            services.AddSingleton(typeof(IModeService), typeof(ModeService));
            services.AddSingleton(typeof(IQuickLinkService), typeof(QuickLinkService));
            services.AddSingleton(typeof(IScaleService), typeof(ScaleService));
            services.AddTransient(typeof(IGroupedScalesService), typeof(GroupedScalesService));
            services.AddSingleton(typeof(IChordTemplateService), typeof(ChordTemplateService));
            services.AddSingleton(typeof(IMusicTheoryService), typeof(MusicTheoryService));
            services.AddSingleton(typeof(IFretboardService), typeof(FretboardService));
            services.AddSingleton(typeof(IScaleGroupingHtmlService), typeof(ScaleGroupingHtmlService));
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