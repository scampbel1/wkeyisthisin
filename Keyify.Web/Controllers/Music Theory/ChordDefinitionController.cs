using AutoMapper;
using FluentValidation;
using Keyify.Infrastructure.DTOs.ChordDefinition;
using Keyify.Infrastructure.Models.ChordDefinition;
using Keyify.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Keyify.Web.Controllers.Music_Theory
{
    public class ChordDefinitionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IValidator<ChordDefinitionInsertRequestDto> _validator;
        private readonly IChordDefinitionService _chordDefinitionService;

        public ChordDefinitionController(IMapper mapper, IValidator<ChordDefinitionInsertRequestDto> validator, IChordDefinitionService chordDefinitionService)
        {
            _mapper = mapper;
            _validator = validator;
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
            try
            {
                if (chordDefintionInsertRequest == null)
                {
                    throw new NullReferenceException($"{nameof(ChordDefinitionInsertRequestDto)} cannot be null");
                }

                var validationResult = _validator.Validate(chordDefintionInsertRequest);

                if (!validationResult.IsValid)
                {
                    var validationErrorMessages = string.Join('.', validationResult.Errors.Select(e => e.ErrorMessage));

                    return Json(new { chordDefintionInsertRequest.Name, WasInserted = false, ErrorMessage = validationErrorMessages });
                }

                var request = _mapper.Map<ChordDefinitionInsertRequest>(chordDefintionInsertRequest);

                var result = await _chordDefinitionService.InsertChordDefinition(request);

                return Json(new { chordDefintionInsertRequest.Name, WasInserted = result.Item1, ErrorMessage = result.Item2 });

            }
            catch (Exception exception)
            {
                return Json(new { chordDefintionInsertRequest.Name, WasInserted = false, ErrorMessage = exception.Message });
            }
        }
    }
}
