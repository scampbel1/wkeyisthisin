using KeyifyScaleFinderClassLibrary.Core.MusicTheory;
using Microsoft.AspNetCore.Mvc;

namespace KeyifyRestApi.Core.Controllers
{
    [Route("api/[controller]")]
    public class ScaleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromBody] string scaleName)
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
