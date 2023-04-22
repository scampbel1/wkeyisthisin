using Keyify.Infrastructure.Models.ChordDefinition;
using Keyify.MusicTheory.Enums;
using Keyify.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<JsonResult> Submit([FromBody] ChordDefinitionInsertRequest request)
        {
            //TODO: Setup proper mapping
            //var intervals = request.Intervals.Select(i => (Interval)Enum.Parse(typeof(Interval), i)).ToArray();

            var intervals = request.Intervals.Select(i => (Interval)i).ToArray();

            var wasInserted = await _chordDefinitionService.InsertChordDefinition(request.Name, intervals);

            return Json(new { request.Name, WasInserted = wasInserted.Item1, ErrorMessage = wasInserted.Item2 });
        }
    }
}
