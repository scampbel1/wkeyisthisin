using AutoMapper;
using Keyify.Infrastructure.DTOs.ChordDefinition;
using Keyify.Infrastructure.Models.ChordDefinition;
using Keyify.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Keyify.Web.Controllers.Music_Theory
{
    public class ChordDefinitionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IChordDefinitionService _chordDefinitionService;

        public ChordDefinitionController(IMapper mapper, IChordDefinitionService chordDefinitionService)
        {
            _mapper = mapper;
            _chordDefinitionService = chordDefinitionService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Submit([FromBody] ChordDefinitionInsertRequestDto chordDefintionInsertRequest)
        {
            var request = _mapper.Map<ChordDefinitionInsertRequest>(chordDefintionInsertRequest);

            var result = await _chordDefinitionService.InsertChordDefinition(request);

            return Json(new { chordDefintionInsertRequest.Name, WasInserted = result.Item1, ErrorMessage = result.Item2 });
        }
    }
}
