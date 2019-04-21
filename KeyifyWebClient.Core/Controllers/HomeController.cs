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

                // Change to action result
                // Accept list of actively selected notes as parameter
                // Create new FretboardWebModel
                // Return View with model as paramter
            return null;
        }
    }
}