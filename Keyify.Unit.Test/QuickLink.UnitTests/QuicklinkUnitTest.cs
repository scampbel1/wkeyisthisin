using Keyify.Web.Enums;
using Keyify.Web.Enums.Tuning;
using KeyifyClassLibrary.Enums;
using Xunit;
using System.Text;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Text.Json;

namespace Keyify.Web.Unit.Test.QuickLink.UnitTests
{
    public class QuicklinkUnitTest
    {
        [Fact]
        public void CreateBase64StringFromParams_DeserializeBase64String_SameParametersValuesReturned()
        {
            //Arrange - Given
            var parameters = new { 
                instrumentType = InstrumentType.Guitar,
                tuning = GuitarTuning.Standard,
                selectedNotes = new Note[] { Note.A, Note.E, Note.Gb },
                selectedScale = "GbAeolian" };

            var sameParametersNotesInDifferentOrder = new { 
                instrumentType = InstrumentType.Guitar,
                tuning = GuitarTuning.Standard,
                selectedNotes = new Note[] { Note.E, Note.A, Note.Gb },
                selectedScale = "GbAeolian" };

            //Act - When
            var parametersHashed = GetHashCodeImplementation(
                parameters.instrumentType,
                parameters.tuning,
                parameters.selectedNotes,
                parameters.selectedScale);

            var sameParametersHashed = GetHashCodeImplementation(
                sameParametersNotesInDifferentOrder.instrumentType,
                sameParametersNotesInDifferentOrder.tuning,
                sameParametersNotesInDifferentOrder.selectedNotes,
                sameParametersNotesInDifferentOrder.selectedScale);

            var parametersJson = JsonSerializer.Serialize(parametersHashed);
            var parametersJson2 = JsonSerializer.Serialize(sameParametersHashed);
            var parametersJsonBytes = Encoding.Default.GetBytes(parametersJson);
            var parametersJsonBytes2 = Encoding.Default.GetBytes(parametersJson2);
            var parametersBase64String = Convert.ToBase64String(parametersJsonBytes);
            var parametersBase64String2 = Convert.ToBase64String(parametersJsonBytes2);

            //Assert - Then
            Assert.Equal(parametersBase64String, parametersBase64String2);
        }

        private static int GetHashCodeImplementation(InstrumentType instrumentType, GuitarTuning tuning, Note[] selectedNotes, string selectedScale)
        {
            int hash = 17;

            hash = hash * 23 + instrumentType.GetHashCode();
            hash = hash * 23 + tuning.GetHashCode();
            hash = hash * 23 + ((IStructuralEquatable)selectedNotes.OrderBy(n => n).ToArray()).GetHashCode(EqualityComparer<Note>.Default);
            hash = hash * 23 + selectedScale.GetHashCode();

            return hash;
        }
    }
}