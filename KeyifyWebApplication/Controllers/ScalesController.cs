using System;
using System.Web.Http;
using KeyifyScaleFinderClassLibrary.MusicTheory;

namespace KeyifyWebApplication.Controllers
{
    public class ScalesController : ApiController
    {
        public IHttpActionResult Get(string scale)
        {
            try
            {
                var scaleEntry = ScaleDictionary.GenerateEntryFromString(scale);
                return Ok(scaleEntry.Scale.Notes);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}