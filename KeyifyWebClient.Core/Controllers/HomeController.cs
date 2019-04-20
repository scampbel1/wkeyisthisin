using KeyifyWebClient.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace KeyifyWebClient.Core.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new FretboardWebModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index([FromBody] string data)
        {
            var model = new FretboardWebModel();

            return View(model);
        }

        [HttpPost]
        public JsonResult UpdateFretboardModel(string data)
        {
            //Update: 20/04/2019 - Poc created, demonstrating Json functionality
            //TODO: Complete method
            return null;
        }
    }
}