using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace Keyify.Controllers
{
    public class HealthCheckController : Controller
    {
        private readonly IConfiguration _configuration;

        public HealthCheckController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var (dbStatus, dbMessage) = DatabaseCheck();

            var db = new
            {
                dbStatus,
                dbMessage,
            };

            var info = new
            {
                db,
            };

            return Ok(info);
        }

        private (string, string) DatabaseCheck()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("databaseConnectionString")))
            {
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
}
