using Keyify.Models;
using Keyify.Service;
using KeyifyClassLibrary.Core.Domain.Tuning;
using KeyifyClassLibrary.Core.Domain.Tuning.Guitar;
using KeyifyWebClient.Core.Models;

namespace Keyify.Controllers
{
    public class GuitarController : InstrumentController
    {
        private readonly ITuning _tuning;
        private readonly string _instrumentName = "Guitar";
        private readonly int _fretCount = 24;

        public GuitarController(IScaleListService dictionary, IScaleService scaleDirectoryService, InstrumentViewModel instrumentViewModel) : base(dictionary, scaleDirectoryService, instrumentViewModel)
        {
            _tuning = new StandardGuitarTuning();

            _instrumentViewModel.UpdateViewModel(_instrumentName, _tuning, _fretCount);
        }
    }
}