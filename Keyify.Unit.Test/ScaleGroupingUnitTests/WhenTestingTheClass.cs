using Keyify.Services.Formatter.Interfaces;
using Keyify.Web.Service;
using Keyify.Web.Services.Interfaces;

namespace Keyify.Web.Unit.Test.ScaleGroupingUnitTests
{
    public abstract class WhenTestingTheClass
    {
        public IScaleGroupingService ItemUnderTest { get; set; }

        public Mock<INoteFormatService> NoteFormatService { get; set; }

        public abstract void Arrange();

        public abstract void Act();

        protected WhenTestingTheClass()
        {
            NoteFormatService = new Mock<INoteFormatService>();
            ItemUnderTest = new ScaleGroupingService(NoteFormatService.Object);
        }
    }
}
