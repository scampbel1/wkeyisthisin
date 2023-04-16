using Keyify.Infrastructure.Models.ChordDefinition;
using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Keyify.Web.Controllers.Music_Theory
{
    public class ChordDefinitionController : Controller
    {
        private readonly IChordDefinitionService _chordDefinitionService;

        public ChordDefinitionController(IChordDefinitionService chordDefinitionService)
        {
            _chordDefinitionService = chordDefinitionService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Find([FromBody] ChordDefinitionCheckRequest request)
        {
            var intervals = ConvertSelectedIntervalStringToIntervalArray(request.Intervals);

            //TODO: Search for existing chord defintiion based on name and intervals

            //TODO: Handle name found, intervals found, or both

            var result = new { request.Name, Intervals = intervals.Select(i => (int)i), Found = true };

            return Json(result);
        }

        //TODO: Replace this by creating array in JS on page
        private Interval[] ConvertSelectedIntervalStringToIntervalArray(string intervals)
        {
            return intervals.Split('-').Select(i => Enum.Parse<Interval>(i)).ToArray();
        }
    }
}
