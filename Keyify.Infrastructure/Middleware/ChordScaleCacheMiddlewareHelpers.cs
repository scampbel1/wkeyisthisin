using Keyify.MusicTheory.Enums;

internal static class ChordScaleCacheMiddlewareHelpers
{

    internal static async Task<Note> FindNextNote(Note currentNote, Interval interval)
    {
        var nextStepIndex = (int)currentNote + (int)interval;

        var result = nextStepIndex > (int)Note.Ab
            ? (Note)(nextStepIndex - (int)Note.Ab) - 1
            : (Note)nextStepIndex;

        return await Task.FromResult(result);
    }

    internal static async Task<Note[]> GenerateChordDefinitionNotes(Note rootNote, Interval[] intervals)
    {
        var count = 0;
        var currentNote = rootNote;
        var chordNotes = new Note[intervals.Length];

        foreach (var interval in intervals)
        {
            currentNote = interval == Interval.R ? currentNote : await FindNextNote(currentNote, interval);
            chordNotes[count] = currentNote;
            count++;
        }

        return chordNotes;
    }
}