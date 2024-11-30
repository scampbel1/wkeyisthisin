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
        [Description("Locrian ♯6")]
        LocrianSharp6, // From Harmonic Minor Modes
        [Description("Ionian ♯5")]
        IonianSharp5, // From Harmonic Minor Modes
        [Description("Dorian ♯4")]
        DorianSharp4, // From Harmonic Minor Modes
        [Description("Phrygian Dominant")]
        PhrygianDominant, // From Harmonic Minor Modes
        [Description("Lydian ♯2")]
        LydianSharp2, // From Harmonic Minor Modes

        [Description("Phrygian ♮6")]
        PhrygianNatural6, // From Melodic Minor Modes
        [Description("Lydian Augmented")]
        LydianAugmented, // From Melodic Minor Modes
        [Description("Lydian Dominant")]
        LydianDominant, // From Melodic Minor Modes
        [Description("Mixolydian ♭6")]
        MixolydianFlat6, // From Melodic Minor Modes
        [Description("Locrian ♮2")]
        LocrianNatural2, // From Melodic Minor Modes

        [Description("Rast")]
        Rast, // Middle Eastern Maqam
        [Description("Bayati")]
        Bayati, // Middle Eastern Maqam
        [Description("Hijaz")]
        Hijaz, // Middle Eastern Maqam
        [Description("Nahawand")]
        Nahawand, // Middle Eastern Maqam
        [Description("Kurd")]
        Kurd, // Middle Eastern Maqam
        [Description("Saba")]
        Saba, // Middle Eastern Maqam
        [Description("Ajam")]
        Ajam, // Middle Eastern Maqam

        [Description("Shang")]
        Shang, // Chinese Scale
        [Description("Jiao")]
        Jiao, // Chinese Scale
        [Description("Zhi")]
        Zhi, // Chinese Scale
        [Description("Yu")]
        Yu, // Chinese Scale

        [Description("Yo")]
        Yo, // Japanese Scale
        [Description("Iwato")]
        Iwato, // Japanese Scale
        [Description("Kokinjoshi")]
        Kokinjoshi, // Japanese Scale
        Overtone,
        Hindu
    }
}