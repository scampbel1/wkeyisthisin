using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;
using System;
using System.Collections.Generic;

namespace Keyify.Web.Unit.Test.ScaleGroupingUnitTests.GenerateScaleGroupingList
{
    public abstract class WhenTestingTheMethod : WhenTestingTheClass
    {
        protected string SelectedScale { get; set; }

        protected InstrumentType InstrumentType { get; set; }

        protected List<ScaleGroupingEntry> Result { get; set; }

        protected IEnumerable<Note> SelectedNotes { get; set; }

        protected IEnumerable<ScaleEntry> Scales { get; set; }

        protected Exception Exception { get; set; }

        public override void Act()
        {
            Arrange();

            try
            {
                Result = ItemUnderTest.GenerateScaleGroupingList(
                    SelectedNotes,
                    Scales,
                    InstrumentType,
                    SelectedScale);
            }
            catch (Exception exception)
            {
                Exception = exception;
            }
        }
    }
}
