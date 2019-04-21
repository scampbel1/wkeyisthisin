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
        public JsonResult UpdateFretboardModel([FromBody] string note)
        {
            //Update: 20/04/2019 - Poc created, demonstrating Json functionality
            //Update: 21/04/2019 - Value being passed - JSON format was incorrect
            //TODO: Complete method
            return null;
        }
    }
}