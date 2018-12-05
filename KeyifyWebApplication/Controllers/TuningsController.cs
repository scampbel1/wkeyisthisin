using System;
using System.Web.Http;
using KeyifyScaleFinderClassLibrary;
using KeyifyScaleFinderClassLibrary.MusicTheory.Tuning;

namespace KeyifyWebApplication.Controllers
{
    public class TuningsController : ApiController
    {
        [Route("api/Tunings/{tuningText}")]
        [HttpGet]
        public IHttpActionResult Get(string tuningText)
        {
            try
            {
                if (tuningText.ToLower().Equals("standard"))
                {
                    var tuning = new StandardTuning();
                    return Ok(tuning.ReturnNotes());
                }

                return BadRequest();
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}