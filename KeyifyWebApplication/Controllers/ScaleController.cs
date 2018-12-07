using System.Web.Http;
using KeyifyScaleFinderClassLibrary.MusicTheory;

namespace KeyifyWebApplication.Controllers
{
    public class ScaleController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get([FromBody] string scaleName)
        {
            if (string.IsNullOrEmpty(scaleName))
                return BadRequest();

            ScaleDictionyEntry scaleEntry = ScaleDictionary.GenerateEntryFromString(scaleName);

            if (scaleEntry != null)
                return Ok(scaleEntry);

            return NotFound();
        }
    }
}
