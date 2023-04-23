using AutoMapper;
using FluentValidation;
using Keyify.Infrastructure.Caches;
using Keyify.Infrastructure.Caches.Interfaces;
using Keyify.Infrastructure.DTOs.ChordDefinition;
using Keyify.Infrastructure.Repository;
using Keyify.Infrastructure.Repository.Interfaces;
using Keyify.Models.Service;
using Keyify.Service;
using Keyify.Service.Interfaces;
using Keyify.Services.Formatter.Interfaces;
using Keyify.Services.Formatter.Services;
using Keyify.Web.Mapping;
using Keyify.Web.Models.Instruments;
using Keyify.Web.Models.ViewModels;
using Keyify.Web.Service;
using Keyify.Web.Service.Interfaces;
using Keyify.Web.Services;
using Keyify.Web.Services.Interfaces;
using Keyify.Web.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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

            SetupMapping(services);
            SetupValidation(services);

            services.AddSingleton(typeof(IScaleDefinitionService), typeof(ScaleDefinitionService));
            services.AddSingleton(typeof(IQuickLinkService), typeof(QuickLinkService));
            services.AddSingleton(typeof(IScaleService), typeof(ScaleService));
            services.AddTransient(typeof(IGroupedScalesService), typeof(GroupedScalesService));
            services.AddSingleton(typeof(IChordDefinitionService), typeof(ChordDefinitionService));
            services.AddSingleton(typeof(IMusicTheoryService), typeof(MusicTheoryService));
            services.AddSingleton(typeof(IFretboardService), typeof(FretboardService));
            services.AddSingleton(typeof(IScaleGroupingHtmlService), typeof(ScaleGroupingHtmlService));
            services.AddSingleton(typeof(IChordDefinitionGroupingHtmlService), typeof(ChordDefinitionsGroupingHtmlService));
            services.AddSingleton(typeof(ISerializationFormatter), typeof(SerializationFormatter));
            services.AddSingleton(typeof(INoteFormatService), typeof(NoteFormatService));
            services.AddSingleton(typeof(IChordDefinitionCache), typeof(ChordDefinitionCache));
            services.AddSingleton(typeof(IScaleDefinitionCache), typeof(ScaleDefinitionCache));

            services.AddTransient(typeof(InstrumentViewModel), typeof(InstrumentViewModel));

            services.AddSingleton<IChordDefinitionRepository>(f =>
                new ChordDefinitionRepository(f.GetService<ILogger<ChordDefinitionRepository>>(),
                    Configuration["ConnectionStrings:SqlServer"],
                    f.GetRequiredService<ISerializationFormatter>()
                ));

            services.AddSingleton<IScaleDefinitionRepository>(f =>
                new ScaleDefinitionRepository(f.GetService<ILogger<ScaleDefinitionRepository>>(),
                    Configuration["ConnectionStrings:SqlServer"],
                    f.GetRequiredService<ISerializationFormatter>()
                ));

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

        private void SetupMapping(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            var mapperConfiguration = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
        }

        private void SetupValidation(IServiceCollection services)
        {
            services.AddScoped<IValidator<ChordDefinitionInsertRequestDto>, ChordDefinitionInsertValidator>();
        }
    }
}