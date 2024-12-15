using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;
using System.Collections.Generic;

namespace Keyify.Web.Unit.Test.ScaleGroupingUnitTests.GenerateScaleGroupingList
{
    public class WhenScaleNotSelected : WhenTestingTheMethod
    {
        public override void Arrange()
        {
            SelectedNotes = new List<Note>() { Note.A, Note.B, Note.C };
            InstrumentType = InstrumentType.Guitar;
            LimitedScaleGroups = new List<ScaleGroupingEntry>();
            //SelectedScale = "D Dorian" //Move to its own test;
            SelectedScale = string.Empty;
        }

        [Fact]
        public void ItDoesNotThrow()
        {
            Act();

            Assert.Null(Exception);
        }
    }
}
