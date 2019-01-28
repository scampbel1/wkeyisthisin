using KeyifyRestApi.Core.Models;
using KeyifyScaleFinderClassLibrary.Core.Instrument;
using KeyifyScaleFinderClassLibrary.Core.MusicTheory.Tuning.Guitar;
using mvc = Microsoft.AspNetCore.Mvc;

namespace KeyifyRestApi.Core.Controllers
{
    [mvc.Route("api/[controller]")]
    public class FretboardController : mvc.ControllerBase
    {
        [mvc.HttpGet]
        public mvc.IActionResult Get([mvc.FromBody] FretboardRequest request)
        {
            try
            {
                CustomGuitarTuning tuning = new CustomGuitarTuning(request.Tuning);
                
                return Ok(Fretboard.PopulateFretboard(tuning, request.FretCount));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
