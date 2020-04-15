using System;
using System.Collections.Generic;
using System.Text;
using KeyifyClassLibrary.Core.MusicTheory.Tuning;

namespace KeyifyClassLibrary.Core.MusicTheory
{
    public class ChordSequence
    {
        public ITuning Notes;
        public List<ChordTab> TabbedChords;

        public ChordSequence(ITuning tuning)
        {
            Notes = tuning;
            TabbedChords = new List<ChordTab>();
        }

        public List<ChordTab> GetChords()
        {
            return this.TabbedChords;
        }

        public ITuning GetTuning()
        {
            return this.Notes;
        }

        public void AddChord(ChordTab ct)
        {
            if (ct.GetChordMap().Count < 6)
            {
                Console.WriteLine("{0} is too few notes\n", ct.GetChordMap().Count);
                //throw new Exception();
            }

            else
            {
                try
                {
                    this.TabbedChords.Add(ct);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    if (ct.GetChordMap().Count > 6) Console.WriteLine("WARNING: Any notes added over 6 will be ommited\n");
                }
            }
        }

        public void PrintTuning()
        {
            var sb = new StringBuilder();

            foreach (var note in Notes.ReturnNotes())
            {
                sb.AppendLine(note.ToString());
            }

            Console.Write(sb.ToString());
        }
    }

    public static class SequencePrinter
    {
        //Reversed for Tabs (upside-down)
        public static void PrintTabs(ChordSequence chordSequence)
        {
            var sequence = chordSequence.GetChords();
            if (sequence.Count > 0)
            {
                int count = sequence.Count;

                while (count >= 0)
                {
                    Console.Write("{0} | ", chordSequence.GetTuning().ReturnNotes()[count]);

                    foreach (ChordTab ct in sequence)
                    {
                        Console.Write("{0} ",

                            !string.IsNullOrEmpty(ct.GetChordMap()[count].Item2.ToString())

                                ? ct.GetChordMap()[count].Item2.ToString()

                                : "x"
                            );
                    }

                    Console.WriteLine("");
                    count--;
                }
            }
        }
    }
}
