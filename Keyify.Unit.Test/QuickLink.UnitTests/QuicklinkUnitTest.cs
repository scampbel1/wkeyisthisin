using Keyify.Web.Enums;
using Keyify.Web.Enums.Tuning;
using KeyifyClassLibrary.Enums;
using Xunit;
using Newtonsoft.Json;
using System.Text;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Keyify.Web.Unit.Test.QuickLink.UnitTests
{
    public class QuicklinkUnitTest
    {
        [Fact]
        public void CreateBase64StringFromParams_DeserializeBase64String_SameParametersValuesReturned()
        {
            //Arrange - Given
            var parameters = new { instrumentType = InstrumentType.Guitar, tuning = GuitarTuning.Standard, selectedNotes = new Note[] { Note.A, Note.E, Note.Gb }, selectedScale = "GbAeolian" };
            var sameParameters = new { instrumentType = InstrumentType.Guitar, tuning = GuitarTuning.Standard, selectedNotes = new Note[] { Note.E, Note.A, Note.Gb }, selectedScale = "GbAeolian" };

            //Act - When
            var parametersHashed = GetHashCodeImplementation(parameters.instrumentType, parameters.tuning, parameters.selectedNotes, parameters.selectedScale);
            var sameParametersHashed = GetHashCodeImplementation(sameParameters.instrumentType, sameParameters.tuning, sameParameters.selectedNotes, sameParameters.selectedScale);

            var json1 = JsonConvert.SerializeObject(parametersHashed);
            var json2 = JsonConvert.SerializeObject(sameParametersHashed);
            var bytes1 = Encoding.Default.GetBytes(json1);
            var bytes2 = Encoding.Default.GetBytes(json2);
            var urlParamBase64String1 = Convert.ToBase64String(bytes1);
            var urlParamBase64String2 = Convert.ToBase64String(bytes2);

            //Assert - Then
            //Assert.NotEqual(parametersHashed, sameParametersHashed);
            Assert.Equal(urlParamBase64String1, urlParamBase64String2);
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