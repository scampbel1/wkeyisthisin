using Keyify.Helper;
using Keyify.Models.Service;
using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Models.MusicTheory;
using KeyifyClassLibrary.Service_Models;
using Xunit;

namespace ScaleDictionaryTests
{
    public class ColloquialLabelUnitTest
    {
        [Theory]
        [InlineData(Mode.Ionian, "Major")]
        public void IonianModeEnumReturnsMajorLabel(Mode selectedMode, string expected)
        {
            var actual = PentatonicModeHelper.GetModeNameColloquialismModeLabel(selectedMode);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(Mode.Aeolian, "Minor")]
        public void AeolianModeEnumReturnsMinorLabel(Mode selectedMode, string expected)
        {
            var actual = PentatonicModeHelper.GetModeNameColloquialismModeLabel(selectedMode);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(Mode.Mixolydian, "")]
        public void MixolydianModeEnumReturnsEmptyString(Mode selectedMode, string expected)
        {
            var actual = PentatonicModeHelper.GetModeNameColloquialismModeLabel(selectedMode);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AbIonianScaleIsConvertedToAbMajor()
        {
            var scale = new Scale(Note.Ab, new ModeDefinition(Mode.Ionian, new Step[] {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h
                 },
                new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                }));

            var expected = "Ab Major";
            var actual = PentatonicModeHelper.GetScaleColloquialism(scale);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DbAeolianScaleIsConvertedToDbMinor()
        {
            var scale = new Scale(
                Note.Db,
                new ModeDefinition(
                    Mode.Aeolian
                    , new Step[] {
                    Step.R,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W
            },
                new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            var expected = "Db Minor";
            var actual = PentatonicModeHelper.GetScaleColloquialism(scale);

            Assert.Equal(expected, actual);
        }
    }
}