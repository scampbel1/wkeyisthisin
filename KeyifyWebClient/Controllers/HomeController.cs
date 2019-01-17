using System.Web.Mvc;
using KeyifyScaleFinderClassLibrary.Instrument;
using KeyifyScaleFinderClassLibrary.MusicTheory.Tuning;
using KeyifyScaleFinderClassLibrary.MusicTheory.Tuning.Guitar;
using KeyifyWebClient.Models;

namespace KeyifyWebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new FretboardWebModel(Fretboard.PopulateFretboard(new StandardGuitarTuning()), 24);
            return View(model);
        }
    }
}