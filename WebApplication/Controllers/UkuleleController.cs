using Keyify.Domain.Tuning.Ukulele;
using Keyify.Models;
using Keyify.Service;
using KeyifyClassLibrary.Core.Domain.Tuning;
using KeyifyWebClient.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Keyify.Controllers
{
    public class UkuleleController : InstrumentController
    {
        private readonly ITuning _tuning;
        private readonly int _fretCount = 13;
        private readonly string _instrumentName = "Ukulele";        
        
        public UkuleleController(IScaleListService dictionary, IScaleService scaleDirectoryService, InstrumentViewModel instrumentViewModel) : base(dictionary, scaleDirectoryService, instrumentViewModel)
        {
            _tuning = new StandardUkuleleTuning();
         
            _instrumentViewModel.UpdateViewModel(_instrumentName, _tuning, _fretCount);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_instrumentViewModel);
        }
    }
}