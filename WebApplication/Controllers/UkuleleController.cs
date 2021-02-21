using Keyify.Domain.Tuning.Ukulele;
using KeyifyClassLibrary.Core.Domain.Tuning;
using KeyifyWebClient.Core.Models;

namespace Keyify.Controllers
{
    public class UkuleleController : InstrumentController
    {
        private readonly ITuning _tuning;
        private readonly int _fretCount = 13;
        private readonly string _instrumentName = "Ukulele";

        public UkuleleController(InstrumentViewModel instrumentViewModel) : base(instrumentViewModel)
        {
            _tuning = new StandardUkuleleTuning();

            _instrumentViewModel.UpdateViewModel(_instrumentName, _tuning, _fretCount);
        }
    }
}