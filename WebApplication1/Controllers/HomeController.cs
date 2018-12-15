using System.Web.Mvc;
using KeyifyScaleFinderClassLibrary.Instrument;
using KeyifyScaleFinderClassLibrary.MusicTheory.Tuning;
using KeyifyWebClient.Models;

namespace KeyifyWebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new FretboardWebModel(Fretboard.PopulateFretboard(new StandardTuning()));
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}