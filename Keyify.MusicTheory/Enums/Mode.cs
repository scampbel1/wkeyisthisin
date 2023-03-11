using System.ComponentModel;

namespace Keyify.MusicTheory.Enums
{
    public enum Mode
    {
        [Description("Ionian")]
        Ionian, //Major
        [Description("Dorian")]
        Dorian,
        [Description("Phrygian")]
        Phrygian,
        [Description("Lydian")]
        Lydian,
        [Description("Mixolydian")]
        Mixolydian,
        [Description("Aeolian")]
        Aeolian, //Natural Minor
        [Description("Locrian")]
        Locrian,
        [Description("Harmonic Minor")]
        HarmonicMinor,
        [Description("Melodic Minor")]
        MelodicMinor,
        [Description("Augmented")]
        Augmented,
        [Description("Major Pentatonic")]
        MajorPentatonic,
        [Description("Minor Pentatonic")]
        MinorPentatonic,
        [Description("Blues")]
        Blues,
        [Description("Whole Tone")]
        WholeTone,
        [Description("Diminished Whole Half")]
        DiminishedWholeHalf,
        [Description("Diminished Half Whole")]
        DiminishedHalfWhole,
        [Description("Arabian")]
        //Mongolian,
        Arabian,
        [Description("Augmented Lydian")]
        AugmentedLydian,
        [Description("Byzantine")]
        Byzantine,
        [Description("Egyptian")]
        //LydianDiminished,
        Egyptian,
        [Description("Hungarian Major")]
        HungarianMajor,
        [Description("Neopolitan Major")]
        NeopolitanMajor,
        [Description("Prometheus")]
        Prometheus,
        [Description("Six Tone Symmetrical")]
        SixToneSymmetrical,
        [Description("Altered")]
        Altered,
        [Description("Balinese Pelog")]
        BalinesePelog, //Same as Pelog
        [Description("Chinese")]
        Chinese,
        [Description("Diminished Lydian")]
        DiminishedLydian,
        [Description("Dorian b2")]
        DorianB2,
        [Description("Eight Tone Spanish")]
        EightToneSpanish,
        //Hindu,
        [Description("Hungarian Minor")]
        HungarianMinor, //Same as Gypsie
        [Description("Kumoi")]
        Kumoi,
        [Description("Locrian 2")]
        Locrian2,
        [Description("Lydian 9")]
        Lydian9,
        [Description("Minor Lydian")]
        MinorLydian,
        [Description("Mixolydian b6")]
        MixolydianB6,
        [Description("Persian")]
        //NeopolitanMinor,
        Persian,
        [Description("Prometheus Neopolitan")]
        PrometheusNeopolitan,
        [Description("Todi Theta")]
        TodiTheta,
        [Description("Altered bb7")]
        AlteredBb7,
        [Description("Augmented Ionian")]
        AugmentedIonian,
        //DoubleHarmonic,
        [Description("Enigmatic")]
        Enigmatic,
        [Description("Hirajoshi")]
        Hirajoshi,
        [Description("Ichikosucho")]
        Ichikosucho,
        [Description("Leading Whole Tone")]
        LeadingWholeTone,
        [Description("Major Phrygian")]
        MajorPhrygian,
        [Description("Neopolitan")]
        Neopolitan,
        [Description("Lydian b7")]
        LydianB7,
        //Overtone,
        [Description("Purvi Theta")]
        PurviTheta,
        [Description("Parallel")]
        Parallel,
    }
}