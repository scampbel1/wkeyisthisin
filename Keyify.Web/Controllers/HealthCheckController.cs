using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;

namespace Keyify.Web.Controllers
{
    public class HealthCheckController(IConfiguration configuration) : Controller
    {
        private readonly IConfiguration _configuration = configuration;

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
            };

            return Ok(info);
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
