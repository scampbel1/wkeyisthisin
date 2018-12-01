using System.Web.Http;
using KeyifyScaleFinderClassLibrary;
using KeyifyScaleFinderClassLibrary.MusicTheory.Tuning;

namespace KeyifyWebApplication.Controllers
{
    public class TuningsController : ApiController
    {
        public IHttpActionResult Get()
        {
            //string tuningText

            //if (tuningText.ToLower().Equals("standard"))
            //{
            var tuning = new StandardTuning();
                return Ok(tuning.ReturnNotes());
            //}

            //return BadRequest("Tuning not found");
        }
    }
}
