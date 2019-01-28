using KeyifyScaleFinderClassLibrary.Core.MusicTheory.Tuning.Guitar;
using Microsoft.AspNetCore.Mvc;

namespace KeyifyRestApi.Core.Controllers
{
    public class TuningsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromBody] string tuningText)
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
                return BadRequest();
            }
        }
    }
}