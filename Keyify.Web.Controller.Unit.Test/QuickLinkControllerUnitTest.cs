using Keyify.Web.Controllers.Quicklink;
using Keyify.Web.Enums;
using Keyify.Web.Enums.Tuning;
using Keyify.Web.Models.QuickLink;
using Keyify.Web.Service.Interfaces;
using KeyifyClassLibrary.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Moq;

namespace Keyify.Web.Controller.Unit.Test
{
    public class QuickLinkControllerUnitTest
    {
        private QuickLinkController? _quickLinkController;
        private Mock<IConfiguration>? m_mockConfiguration;
        private Mock<IQuickLinkService>? m_mockQuickLinkService;

        [Fact]
        public void ValidTokenPassed_TokenConverted_RetrievesGuitarQuickLink_RedirectToHomePageGuitarPage()
        {
            //Arrange
            var validToken = "validToken";
            var expected = "/Guitar/";

            m_mockConfiguration = new Mock<IConfiguration>();
            m_mockQuickLinkService = new Mock<IQuickLinkService>();

            m_mockConfiguration.Setup(c => c[It.IsAny<string>()]).Returns(string.Empty);

            m_mockQuickLinkService.Setup(q => q.DeserializeQuickLink(validToken)).Returns(new QuickLink()
            {
                InstrumentType = InstrumentType.Guitar,
                Tuning = Tuning.Guitar_Standard,
                SelectedNotes = new Note[] { Note.A, Note.E, Note.Gb },
                SelectedScale = "GbAeolian"
            });

            _quickLinkController = new QuickLinkController(m_mockConfiguration.Object, m_mockQuickLinkService.Object)
            {
                TempData = new TempDataDictionary(
                    Mock.Of<HttpContext>(),
                    Mock.Of<ITempDataProvider>())
            };

            //Act
            var result = (RedirectResult)_quickLinkController.Index(validToken);

            //Assert
            Assert.Equal(expected, result.Url);
        }
    }
}
