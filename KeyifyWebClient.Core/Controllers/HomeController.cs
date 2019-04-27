using System.Linq;
using KeyifyWebClient.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace KeyifyWebClient.Core.Controllers
{
    public class HomeController : Controller
    {
        FretboardWebModel model;

        public HomeController()
        {
            model = new FretboardWebModel();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateFretboardModel([FromBody] string[] notes)
        {
            foreach (var note in notes)
            {
                model.Notes.Remove(note);
                model.Notes.Add(note, true);
            }

            return PartialView("FretboardMain", model);
        }
    }
}