using Keyify.Infrastructure.Caches.Interfaces;
using Keyify.Infrastructure.Repository;
using Keyify.Models.Service;
using Keyify.Service;
using Keyify.Service.Interfaces;
using Keyify.Services.Formatter.Interfaces;
using Keyify.Services.Formatter.Services;
using Keyify.Web.Infrastructure.Caches;
using Keyify.Web.Infrastructure.Repository.Interfaces;
using Keyify.Web.Models.Instruments;
using Keyify.Web.Models.ViewModels;
using Keyify.Web.Service;
using Keyify.Web.Service.Interfaces;
using Keyify.Web.Services;
using Keyify.Web.Services.Interfaces;
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

            services.AddSingleton(typeof(IModeService), typeof(ModeService));
            services.AddSingleton(typeof(IQuickLinkService), typeof(QuickLinkService));
            services.AddSingleton(typeof(IScaleService), typeof(ScaleService));
            services.AddTransient(typeof(IGroupedScalesService), typeof(GroupedScalesService));
            services.AddSingleton(typeof(IChordDefinitionService), typeof(ChordDefinitionService));
            services.AddSingleton(typeof(IMusicTheoryService), typeof(MusicTheoryService));
            services.AddSingleton(typeof(IFretboardService), typeof(FretboardService));
            services.AddSingleton(typeof(IScaleGroupingHtmlService), typeof(ScaleGroupingHtmlService));
            services.AddSingleton(typeof(IChordDefinitionGroupingHtmlService), typeof(ChordDefinitionsGroupingHtmlService));
            services.AddSingleton(typeof(IChordDefinitionDataCache), typeof(ChordDefinitionDataCache));
            services.AddSingleton(typeof(IChordDefinitionRepository), typeof(ChordDefinitionRepository));
            services.AddSingleton(typeof(INoteFormatService), typeof(NoteFormatService));


            services.AddSingleton(typeof(ModeDataCache), typeof(ModeDataCache));
            services.AddTransient(typeof(InstrumentViewModel), typeof(InstrumentViewModel));
            services.AddSingleton(f => new Fretboard(f.GetRequiredService<INoteFormatService>().SharpNoteDictionary));
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