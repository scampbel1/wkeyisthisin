using System.Web.Http;
using KeyifyScaleFinderClassLibrary.MusicTheory.Tuning;

namespace KeyifyWebApplication.Controllers
{
    public class TuningsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get([FromBody] string tuningText)
        {
            try
            {
                if (tuningText.ToLower().Equals("standard"))
                    return Ok(new StandardTuning().ReturnNotes());

                try
                {
                    return Ok(new CustomTuning(tuningText).ReturnNotes());
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