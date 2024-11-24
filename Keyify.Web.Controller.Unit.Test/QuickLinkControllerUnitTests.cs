using Keyify.MusicTheory.Enums;
using Keyify.Web.Controllers.Quicklink;
using Keyify.Web.Models.QuickLink;
using Keyify.Web.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;

namespace Keyify.Web.Controller.Unit.Test
{
    public class QuickLinkControllerUnitTests
    {
        private QuickLinkController? _quickLinkController;
        private Mock<IConfiguration>? m_mockConfiguration;
        private Mock<IQuickLinkService>? m_mockQuickLinkService;

        [Fact]
        public void ValidTokenPassed_TokenConverted_RetrievesGuitarQuickLink_RedirectToHomePageGuitarPage()
        {
            //Arrange
            const string expected = "/Guitar/";
            const string validToken = "validToken";

            m_mockConfiguration = new Mock<IConfiguration>();
            m_mockQuickLinkService = new Mock<IQuickLinkService>();

            m_mockConfiguration.Setup(c => c[It.IsAny<string>()]).Returns(string.Empty);

            m_mockQuickLinkService.Setup(q => q.DeserializeQuickLink(validToken)).Returns(new QuickLink()
            {
                InstrumentType = InstrumentType.Guitar,
                Tuning = [Note.E, Note.A, Note.D, Note.G, Note.B, Note.E],
                SelectedNotes = [Note.A, Note.E, Note.Gb],
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

        [Fact]
        public void InvalidTokenPassed_ExceptionThrown_RedirectedToIndexPage()
        {
            //Arrange
            const string expected = "/";
            const string invalidToken = "invalidToken";

            m_mockConfiguration = new Mock<IConfiguration>();
            m_mockQuickLinkService = new Mock<IQuickLinkService>();

            m_mockConfiguration.Setup(c => c[It.IsAny<string>()]).Returns(string.Empty);

            m_mockQuickLinkService.Setup(q => q.DeserializeQuickLink(invalidToken)).Throws(new FormatException("Invalid Format"));

            _quickLinkController = new QuickLinkController(m_mockConfiguration.Object, m_mockQuickLinkService.Object)
            {
                TempData = new TempDataDictionary(
                    Mock.Of<HttpContext>(),
                    Mock.Of<ITempDataProvider>())
            };

            //Act
            var result = (RedirectResult)_quickLinkController.Index(invalidToken);

            //Assert
            Assert.Equal(expected, result.Url);
        }

        [Fact]
        public void NullToken_ExceptionThrown_RedirectedToIndexPage()
        {
            //Arrange
            const string expected = "/";
            const string? invalidToken = null;

            m_mockConfiguration = new Mock<IConfiguration>();
            m_mockQuickLinkService = new Mock<IQuickLinkService>();

            m_mockConfiguration.Setup(c => c[It.IsAny<string>()]).Returns(string.Empty);

            m_mockQuickLinkService.Setup(q => q.DeserializeQuickLink(invalidToken)).Throws(new NullReferenceException("Null Reference"));

            _quickLinkController = new QuickLinkController(m_mockConfiguration.Object, m_mockQuickLinkService.Object)
            {
                TempData = new TempDataDictionary(
                    Mock.Of<HttpContext>(),
                    Mock.Of<ITempDataProvider>())
            };

            //Act
            var result = (RedirectResult)_quickLinkController.Index(invalidToken);

            //Assert
            Assert.Equal(expected, result.Url);
        }
    }
}
