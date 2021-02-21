using Keyify.Domain.Tuning.Bass;
using KeyifyClassLibrary.Models.Interfaces;
using KeyifyWebClient.Models.ViewModels;

namespace Keyify.Controllers
{
    public class BassController : InstrumentController
    {
        private readonly ITuning _tuning;
        private const int _fretCount = 21;
        private const string _instrumentName = "Bass";

        public BassController(InstrumentViewModel instrumentViewModel) : base(instrumentViewModel)
        {
            _tuning = new StandardBassTuning();

            _instrumentViewModel.UpdateViewModel(_instrumentName, _tuning, _fretCount);
        }
    }
}