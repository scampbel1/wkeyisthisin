using System.Web.Http;
using KeyifyScaleFinderClassLibrary.Instrument;
using KeyifyScaleFinderClassLibrary.MusicTheory.Tuning;
using KeyifyWebApplication.Models;

namespace KeyifyWebApplication.Controllers
{
    public class FretboardController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get([FromBody] FretboardRequest request)
        {
            try
            {
                CustomTuning tuning = new CustomTuning(request.Tuning);

                return Ok(Fretboard.PopulateFretboard(tuning, request.FretCount));
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}
