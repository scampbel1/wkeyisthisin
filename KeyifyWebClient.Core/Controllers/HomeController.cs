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
        public JsonResult UpdateFretboardModel([FromBody] string data)
        {
            //TODO: Read this - https://www.c-sharpcorner.com/UploadFile/2ed7ae/jsonresult-type-in-mvc/
            //      Complete method based on this information... this should point you in the right direction

            return null;
        }
    }
}