using AutoMapper;
using FluentValidation;
using Keyify.Infrastructure.Caches;
using Keyify.Infrastructure.DTOs.ChordDefinition;
using Keyify.Infrastructure.Middleware;
using Keyify.Infrastructure.Repository;
using Keyify.Infrastructure.Repository.Interfaces;
using Keyify.Models.Service;
using Keyify.Service;
using Keyify.Service.Interfaces;
using Keyify.Services.Formatter.Interfaces;
using Keyify.Services.Formatter.Services;
using Keyify.Services.Models;
using Keyify.Web.Converters;
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

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new NoteConverter());
                    options.JsonSerializerOptions.Converters.Add(new NoteListConverter());
                });

            services.AddApplicationInsightsTelemetry(Configuration);

            SetupMapping(services);
            SetupDatabase(services);
            SetupValidation(services);
            SetupCaches(services);

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
            services.AddTransient(typeof(InstrumentViewModel), typeof(InstrumentViewModel));
            services.AddSingleton(f => new Fretboard(f.GetRequiredService<INoteFormatService>().SharpNoteDictionary));

            services.AddAntiforgery(options =>
            {
                options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
            });
        }

        private static void SetupCaches(IServiceCollection services)
        {
            services.AddTransient<ChordScaleCacheMiddleware>();
            services.AddSingleton<CacheSignal<ScaleDefinition>>();
            services.AddSingleton<CacheSignal<ChordDefinition>>();
        }

        private void SetupDatabase(IServiceCollection services)
        {
            var databaseConfiguration = Configuration.GetConnectionString("databaseConnectionString");

            services.AddSingleton<IChordDefinitionRepository>(f => new ChordDefinitionRepository(
                f.GetService<ILogger<ChordDefinitionRepository>>(),
                databaseConfiguration,
                f.GetRequiredService<ISerializationFormatter>()));

            services.AddSingleton<IScaleDefinitionRepository>(f => new ScaleDefinitionRepository(
                f.GetService<ILogger<ScaleDefinitionRepository>>(),
                databaseConfiguration,
                f.GetRequiredService<ISerializationFormatter>()));
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

        public void Configure(
            IApplicationBuilder applicationBuilder,
            IWebHostEnvironment webHostEnvironment)
        {
            SetupMiddleware(applicationBuilder);

            applicationBuilder.UseDeveloperExceptionPage();
            applicationBuilder.UseHttpsRedirection();
            applicationBuilder.UseStaticFiles();
            applicationBuilder.UseRouting();
            applicationBuilder.UseAuthorization();
            applicationBuilder.UseForwardedHeaders();
            applicationBuilder.UseAntiforgery();

            applicationBuilder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Instrument}/{action=Index}");
            });
        }

        private void SetupMiddleware(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ChordScaleCacheMiddleware>();
        }
    }
}