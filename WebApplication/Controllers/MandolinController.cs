using Keyify.Domain.Tuning.Mandolin;
using Keyify.Models;
using Keyify.Service;
using KeyifyClassLibrary.Core.Domain.Tuning;
using KeyifyWebClient.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Keyify.Controllers
{
    public class MandolinController : InstrumentController
    {
        private readonly ITuning _tuning;
        private readonly int _fretCount = 20;
        private readonly string _instrumentName = "Mandolin";        

        public MandolinController(IScaleListService dictionary, IScaleService scaleDirectoryService, InstrumentViewModel instrumentViewModel) : base(dictionary, scaleDirectoryService, instrumentViewModel)
        {
            _tuning = new StandardMandolinTuning();
            
            _instrumentViewModel.UpdateViewModel(_instrumentName, _tuning, _fretCount);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_instrumentViewModel);
        }
    }
}