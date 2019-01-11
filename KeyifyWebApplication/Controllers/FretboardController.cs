using System.Web.Http;
using KeyifyScaleFinderClassLibrary.Instrument;
using KeyifyScaleFinderClassLibrary.MusicTheory.Tuning.Guitar;
using KeyifyRestApi.Models;

namespace KeyifyRestApi.Controllers
{
    public class FretboardController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get([FromBody] FretboardRequest request)
        {
            try
            {
                CustomGuitarTuning tuning = new CustomGuitarTuning(request.Tuning);

                return Ok(Fretboard.PopulateFretboard(tuning, request.FretCount));
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}
