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