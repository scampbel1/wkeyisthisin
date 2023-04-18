﻿using Keyify.Infrastructure.Models.ChordDefinition;
using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<JsonResult> Submit([FromBody] ChordDefinitionCheckRequest request)
        {
            var intervals = ConvertSelectedIntervalStringToIntervalArray(request.Intervals);

            var wasInserted = await _chordDefinitionService.InsertChordDefinition(request.Name, intervals);

            return Json(new { request.Name, Intervals = intervals.Select(i => (int)i), WasInserted = wasInserted.Item1, ErrorMessage = wasInserted.Item2 });
        }

        //TODO: Replace this by creating array in JS on page
        private Interval[] ConvertSelectedIntervalStringToIntervalArray(string intervals)
        {
            return intervals.Split('-').Select(i => Enum.Parse<Interval>(i)).ToArray();
        }
    }
}
