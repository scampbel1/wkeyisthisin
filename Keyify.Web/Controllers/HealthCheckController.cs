using Keyify.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Keyify.Web.Controllers
{
    public class HealthCheckController(IConfiguration configuration, IMemoryCache memoryCache) : Controller
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly IMemoryCache _memoryCache = memoryCache;

        [HttpGet]
        public ActionResult Index()
        {
            var (dbStatus, dbMessage) = DatabaseCheck();

            var info = new
            {
                db = new
                {
                    dbStatus,
                    dbMessage,
                },
                cache = new
                {
                    chordDefinitions = GetChordDefinitionCount(),
                    scaleDefinitions = GetScaleDefinitionCount(),
                },
            };

            return Ok(info);

            int GetChordDefinitionCount()
            {
                List<ChordDefinition> chordDefinitions;

                _memoryCache.TryGetValue("ChordDefinitions", out chordDefinitions!);

                return chordDefinitions.Count;
            }

            int GetScaleDefinitionCount()
            {
                List<ScaleDefinition> scaleDefinitions;

                _memoryCache.TryGetValue("ScaleDefinitions", out scaleDefinitions!);

                return scaleDefinitions.Count;
            }
        }

        private (string, string) DatabaseCheck()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("databaseConnectionString"));
            try
            {
                connection.Open();

                return ("Ok!", string.Empty);
            }
            catch (Exception exception)
            {
                return ("Not Connected!", exception.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
