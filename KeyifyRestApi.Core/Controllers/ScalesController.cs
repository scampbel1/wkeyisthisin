using System;
using System.Collections.Generic;
using System.Linq;
using KeyifyScaleFinderClassLibrary.Core.MusicTheory;
using KeyifyScaleFinderClassLibrary.Core.MusicTheory.Helper;
using Microsoft.AspNetCore.Mvc;

namespace KeyifyRestApi.Core.Controllers
{
    public class ScalesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromBody] string[] notes)
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
                return BadRequest(e);
            }
        }
    }
}