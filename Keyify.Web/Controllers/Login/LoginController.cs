using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Keyify.Web.Controllers.Login
{
    public class LoginController : Controller
    {
        private readonly IDataProtectionProvider _protectionProvider;
        private readonly IDataProtector _protector;

        public LoginController()
        {
            _protectionProvider = DataProtectionProvider.Create("keyify");
            _protector = _protectionProvider.CreateProtector("auth-cookie");
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            var authCookie = HttpContext.Request.Headers.Cookie.FirstOrDefault(c => c.Contains("auth="));

            if (string.IsNullOrEmpty(authCookie))
            {
                return View("Index", string.Empty);
            }

            var protectedPayload = authCookie.Split('=').Last();

            var payload = _protector.Unprotect(protectedPayload);

            var parts = payload.Split(':');
            var key = parts[0];
            var value = parts[1];

            var model = string.IsNullOrWhiteSpace(value) ? string.Empty : value;

            return View("Index", model);
        }

        [HttpGet("/Login")]
        public string Login()
        {
            var response = $"auth={_protector.Protect("usr:sean")}";

            HttpContext.Response.Headers["set-cookie"] = response;

            return "ok";
        }
    }
}
