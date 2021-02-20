using Keyify.Domain.Tuning.Bass;
using Keyify.Models;
using Keyify.Service;
using KeyifyClassLibrary.Core.Domain.Tuning;
using KeyifyWebClient.Core.Models;

namespace Keyify.Controllers
{
    public class BassController : InstrumentController
    {
        private readonly ITuning _tuning;
        private const int _fretCount = 21;
        private const string _instrumentName = "Bass";

        public BassController(IScaleListService dictionary, IScaleService scaleDirectoryService, InstrumentViewModel instrumentViewModel) : base(dictionary, scaleDirectoryService, instrumentViewModel)
        {
            _tuning = new StandardBassTuning();

            _instrumentViewModel.UpdateViewModel(_instrumentName, _tuning, _fretCount);
        }
    }
}