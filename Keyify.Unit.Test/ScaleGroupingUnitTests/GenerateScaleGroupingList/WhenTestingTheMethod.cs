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

        protected List<ScaleGroupingEntry> LimitedScaleGroups { get; set; }

        protected Exception Exception { get; set; }

        public override void Act()
        {
            Arrange();

            try
            {
                Result = ItemUnderTest.GenerateScaleGroupingList(
                    SelectedNotes,
                    InstrumentType,
                    LimitedScaleGroups,
                    SelectedScale);
            }
            catch (Exception exception)
            {
                Exception = exception;
            }
        }
    }
}
