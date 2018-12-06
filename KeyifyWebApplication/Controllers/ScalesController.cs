using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using KeyifyScaleFinderClassLibrary.MusicTheory;
using KeyifyScaleFinderClassLibrary.MusicTheory.Helper;

namespace KeyifyWebApplication.Controllers
{
    public class ScalesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get([FromUri] string[] notes)
        {
            try
            {
                if (!notes.Any())
                {
                    List<ScaleDictionyEntry> scales = ScaleDictionary.GenerateDictionary();

                    if (scales != null) return Ok(scales);
                }

                var results =
                    ScaleMatcher.GetMatchedScales(KeyifyElementStringConverter.ConvertStringArrayIntoNotes(notes));

                if (results.Any())
                    return Ok(results);

                    return Ok($"No elements found in according to search: {string.Join("", notes)}");
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("api/Scales/ScaleName/{scaleName}")]
        [HttpGet]
        public IHttpActionResult ScaleName(string scaleName)
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