using System;
using System.Globalization;
using System.Web.Http;
using KeyifyScaleFinderClassLibrary.MusicTheory.Tuning;

namespace KeyifyWebApplication.Controllers
{
    public class KeyController : ApiController
    {
        private readonly string _initialMessage;

        public KeyController()
        {
            var currentTime = DateTime.Now;
            _initialMessage = currentTime.ToString(CultureInfo.CurrentCulture);
        }

        public IHttpActionResult Get(ITuning tuning)
        {
//            if (notes are invalid)
//            {
//                return BadRequest("Tuning note(s) contain invalid characters.");
//            }

            try
            {
                var myObject = new { NumberIndex = new[] { 0, 1 }, Name = "Anonymous Object made by Sean Campbell" };

                return Ok(myObject);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
