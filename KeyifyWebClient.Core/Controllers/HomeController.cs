using System.Linq;
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
        public ActionResult UpdateFretboardModel([FromBody] string note)
        {
            //Update: 20/04/2019 - Poc created, demonstrating Json functionality
            //Update: 21/04/2019 - Value being passed - JSON format was incorrect
            //TODO: Complete method

            // Send entire model to controller
            // Parse model from JSON on controller
            // Return View with model as paramter

            var model = new FretboardWebModel();

            model.Notes.Remove(note);
            model.Notes.Add(note, true);

            return View("Index", model);
        }
    }
}