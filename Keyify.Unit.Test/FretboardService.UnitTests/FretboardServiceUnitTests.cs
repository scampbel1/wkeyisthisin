using Keyify.MusicTheory.Enums;
using Keyify.Web.Models.Instruments;
using Keyify.Web.Service.Interfaces;
using Keyify.Web.Services;
using Keyify.Web.Services.Interfaces;
using KeyifyWebClient.Models.Instruments;

namespace Keyify.Web.Unit.Test.FretboardServiceTest.UnitTests
{
    public class FretboardServiceUnitTests
    {
        protected readonly Mock<IMusicTheoryService> m_MockMusicTheoryService;
        protected readonly Mock<IGroupedScalesService> m_MockGroupedScalesService;
        protected readonly FretboardService _service;
        protected readonly Fretboard _fretboard;

        public FretboardServiceUnitTests()
        {
            m_MockMusicTheoryService = new Mock<IMusicTheoryService>();
            m_MockGroupedScalesService = new Mock<IGroupedScalesService>();
            _service = new FretboardService(m_MockMusicTheoryService.Object, m_MockGroupedScalesService.Object);

            _fretboard = new Fretboard()
            {
                FretCount = 15,
                InstrumentType = InstrumentType.Guitar,
                Tuning = new StandardGuitarTuning()
            };
        }
    }
}
