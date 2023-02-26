using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;

namespace Keyify.Web.Infrastructure.Caches
{
    public class ScaleDefinitionCache
    {
        public List<ScaleDefinition> ScaleDefinitions => GenerateModeDefinitions();

        //TODO: Add duplicate Modes that contain the same note sets
        private List<ScaleDefinition> GenerateModeDefinitions()
        {
            var modeDefinitionDictionary = new Dictionary<string, ScaleDefinition>();

            var ionianDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var aeolianDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var phrygianDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var lydianDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var mixolydianDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var locrianDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.FlatFifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var dorianDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var harmonicMinorDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var melodicMinorDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var augmentedDegrees = new string[] {
                     Degree.First,
                     Degree.FlatThird,
                     Degree.Third,
                     Degree.Fifth,
                     Degree.SharpFifth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var minorPentatonicDegrees = new string[] {
                     Degree.First,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSeventh,
                     Degree.Eighth
            };

            var majorPentatonicDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Eighth
                };

            var bluesDegrees = new string[] {
                     Degree.First,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var wholeToneDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.SharpFifth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var diminishedWholeHalfDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.FlatFifth,
                     Degree.FlatSixth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var diminishedHalfWholeDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.FlatFourth,
                     Degree.FlatFifth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var arabianDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.SharpFourth,
                     Degree.SharpFifth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var augmentedLydianDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.SharpFifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var byzantineDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var egyptianDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var hungarianMajorDegrees = new string[] {
                     Degree.First,
                     Degree.SharpSecond,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var neopolitanMajorDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var balinesePelogDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Eighth
                };

            var prometheusDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.FlatFifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var sixToneSymmertricalDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.SharpFifth,
                     Degree.Sixth,
                     Degree.Eighth
                };

            var alteredDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.FlatFourth,
                     Degree.FlatFifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var chineseDegrees = new string[] {
                     Degree.First,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var diminishedLydianDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var eightToneSpanishDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.SharpSecond,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.FlatFifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var hinduDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var hungarianMinorDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var kumoiDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Eighth
                };

            var locrian2Degrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.FlatFifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var lydian9Degrees = new string[] {
                     Degree.First,
                     Degree.SharpSecond,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var minorLyrdianDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var mixolydianB6Degrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var persianDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.FlatFifth,
                     Degree.FlatSixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var prometheusNeopolitanDegree = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.Third,
                     Degree.FlatFifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var todiThetaDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var alteredBb7Degrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.FlatFourth,
                     Degree.FlatFifth,
                     Degree.FlatSixth,
                     Degree.FlatFlatSeventh,
                     Degree.Eighth
                };

            var augmentedIonianDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.SharpFifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var enigmaticDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.SharpFifth,
                     Degree.SharpSixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var hirajoshiDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Eighth
                };

            var ichikosuchoDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var leadingWholeToneDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.SharpFifth,
                     Degree.SharpSixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var lydianB7Degrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var majorPhrygianDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var neopolitanDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var overtoneDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var purviThetaDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var dorian_b2Degrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Ionian, ionianSteps, ionianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Aeolian, aeolianSteps, aeolianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Phrygian, phrygianSteps, phrygianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Lydian, lydianSteps, lydianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Mixolydian, mixolydianSteps, mixolydianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Locrian, locrianSteps, locrianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Dorian, dorianSteps, dorianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.HarmonicMinor, harmonicMinorSteps, harmonicMinorDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.MelodicMinor, melodicMinorSteps, melodicMinorDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Augmented, augmentedSteps, augmentedDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.MinorPentatonic, minorPentatonicSteps, minorPentatonicDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.MajorPentatonic, majorPentatonicSteps, majorPentatonicDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Blues, bluesSteps, bluesDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.WholeTone, wholeToneSteps, wholeToneDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.DiminishedWholeHalf, diminishedWholeHalfSteps, diminishedWholeHalfDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.DiminishedHalfWhole, diminishedHalfWholeSteps, diminishedHalfWholeDegrees);
            //InsertDictionaryEntry(modeDefinitionDictionary, Mode.Mongolian, mongolianSteps, mongolianDegrses); //The same as Major Pentatonic
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Arabian, arabianSteps, arabianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.AugmentedLydian, augmentedLydianSteps, augmentedLydianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Byzantine, byzantineSteps, byzantineDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Egyptian, egyptianSteps, egyptianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.HungarianMajor, hungarianMajorSteps, hungarianMajorDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.NeopolitanMajor, neopolitanMajorSteps, neopolitanMajorDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.BalinesePelog, balinesePelogSteps, balinesePelogDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Prometheus, prometheusSteps, prometheusDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.SixToneSymmetrical, sixToneSymmertricalSteps, sixToneSymmertricalDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Altered, alteredSteps, alteredDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Chinese, chineseSteps, chineseDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.DiminishedLydian, diminishedLydianSteps, diminishedLydianDegrees); //Dorian #4
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.EightToneSpanish, eightToneSpanishSteps, eightToneSpanishDegrees);
            //InsertDictionaryEntry(modeDefinitionDictionary, Mode.Hindu, hinduSteps, hinduDegrees); //The Hindu scale (also known as the Aeolian dominant scale, Olympian Scale, Mixolydian ♭6 [or ♭13], Aeolian major, and melodic major
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.HungarianMinor, hungarianMinorSteps, hungarianMinorDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Kumoi, kumoiSteps, kumoiDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Locrian2, locrian2Steps, locrian2Degrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Lydian9, lydian9Steps, lydian9Degrees); //Lydian #9
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.MinorLydian, minorLyrdianSteps, minorLyrdianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.MixolydianB6, mixolydianB6Steps, mixolydianB6Degrees);
            //InsertDictionaryEntry(modeDefinitionDictionary, Mode.NeopolitanMinor, neopolitanMinorSteps, neopolitanMinorDegrees); //Same as Phrygian
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Persian, persianSteps, persianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.PrometheusNeopolitan, prometheusNeopolitanSteps, prometheusNeopolitanDegree);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.TodiTheta, todiThetaSteps, todiThetaDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.AlteredBb7, alteredBb7Steps, alteredBb7Degrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.AugmentedIonian, augmentedIonianSteps, augmentedIonianDegrees);
            //InsertDictionaryEntry(modeDefinitionDictionary, Mode.DoubleHarmonic, doubleHarmonicSteps, doubleHarmonicDegrees); //Same as Byzantine
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Enigmatic, enigmaticSteps, enigmaticDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Ichikosucho, ichikosuchoSteps, ichikosuchoDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Hirajoshi, hirajoshiSteps, hirajoshiDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.LeadingWholeTone, leadingWholeToneSteps, leadingWholeToneDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.LydianB7, lydianB7Steps, lydianB7Degrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.MajorPhrygian, majorPhrygianSteps, majorPhrygianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Neopolitan, neopolitanSteps, neopolitanDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.PurviTheta, purviThetaSteps, purviThetaDegrees);
            //InsertDictionaryEntry(modeDefinitionDictionary, Mode.Overtone, overtoneSteps, overtoneDegrees); //Same as Lydian b7
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.DorianB2, dorian_b2Steps, dorian_b2Degrees);

            return modeDefinitionDictionary.Select(m => m.Value).ToList();
        }

        private void InsertDictionaryEntry(Dictionary<string, ScaleDefinition> dictionary, Mode mode, Interval[] steps, string[] degrees)
        {
            var key = string.Join(',', degrees);

            switch (mode)
            {
                case Mode.WholeTone:
                    dictionary.Add(key, new ScaleDefinition(mode, steps, degrees, new[] { Note.D, Note.F }));
                    break;
                case Mode.DiminishedWholeHalf:
                case Mode.DiminishedHalfWhole:
                    dictionary.Add(key, new ScaleDefinition(mode, steps, degrees, new[] { Note.C, Note.Db, Note.D }));
                    break;
                default:
                    dictionary.Add(key, new ScaleDefinition(mode, steps, degrees));
                    break;
            }
        }
    }
}