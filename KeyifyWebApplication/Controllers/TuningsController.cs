using System.Web.Http;
using KeyifyScaleFinderClassLibrary.MusicTheory.Tuning;
using KeyifyScaleFinderClassLibrary.MusicTheory.Tuning.Guitar;

namespace KeyifyRestApi.Controllers
{
    public class TuningsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get([FromBody] string tuningText)
        {
            try
            {
                if (tuningText.ToLower().Equals("standard"))
                    return Ok(new StandardGuitarTuning().ReturnNotes());

                try
                {
                    return Ok(new CustomGuitarTuning(tuningText).ReturnNotes());
                }
                catch
                {
                    return BadRequest();
                }
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}