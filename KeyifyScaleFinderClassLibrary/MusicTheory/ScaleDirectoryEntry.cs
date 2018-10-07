using KeyifyScaleFinderClassLibrary.MusicTheory.Enums;

namespace KeyifyScaleFinderClassLibrary.MusicTheory
{
    public static partial class HeptatonicScaleModeDictionary
    {
        public class ScaleDirectoryEntry
        {
            public HeptatonicMode Mode { get; set; }
            public ScaleStep[] ScaleSteps { get; set; }

            public ScaleDirectoryEntry(HeptatonicMode mode, ScaleStep[] scaleSteps)
            {
                Mode = mode;
                ScaleSteps = scaleSteps;
            }
        }
    }
}

/*
 * Total possible scales within an octave - using the chromatic scale (12 notes)
 * http://mathcentral.uregina.ca/QQ/database/QQ.09.01/terence1.html
 */

// Music of the common practice periods(1600–1900) uses three types of scale:
// The diatonic scale(seven notes)—this includes the major scale
// and the natural minor
// The melodic and harmonic minor scales(seven notes)        


// Mode Also known as 	Tonic relative to major scale Interval sequence Example
// Ionian      Major scale I            T-T-s-T-T-T-s    C-D-E-F-G-A-B-C
// Dorian      II                       T-s-T-T-T-s-T    D-E-F-G-A-B-C-D
// Phrygian    III                      s-T-T-T-s-T-T    E-F-G-A-B-C-D-E
// Lydian      IV                       T-T-T-s-T-T-s    F-G-A-B-C-D-E-F
// Mixolydian  Dominant scale  V        T-T-s-T-T-s-T    G-A-B-C-D-E-F-G
// Aeolian     Natural minor scale VI   T-s-T-T-s-T-T    A-B-C-D-E-F-G-A
// Locrian     VII                      s-T-T-s-T-T-T    B-C-D-E-F-G-A-B


// Octatonic(8 notes per octave): used in jazz and modern classical music
// Heptatonic(7 notes per octave): the most common modern Western scale
// Hexatonic(6 notes per octave): common in Western folk music
// Pentatonic(5 notes per octave): the anhemitonic form(lacking semitones) is common in folk music, especially in oriental music; also known as the "black note" scale
// Tetratonic(4 notes), tritonic(3 notes), and ditonic(2 notes): generally limited to prehistoric("primitive") music
// Monotonic(1 note): limited use in liturgy, and for effect in modern art music[citation needed]