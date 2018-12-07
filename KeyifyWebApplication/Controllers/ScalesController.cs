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
        public IHttpActionResult Get([FromBody] string[] notes)
        {
            try
            {
                if (notes == null || !notes.Any())
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
    }
}