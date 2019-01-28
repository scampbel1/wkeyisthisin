using KeyifyScaleFinderClassLibrary.Core.Instrument;
using KeyifyScaleFinderClassLibrary.Core.MusicTheory.Tuning.Guitar;
using KeyifyWebClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace KeyifyWebClient.Core.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new FretboardWebModel(Fretboard.PopulateFretboard(new StandardGuitarTuning()), 24);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(FretboardWebModel model)
        {
            return View(model);
        }
    }
}