using Keyify.Web.Models.Tunings;
using KeyifyClassLibrary.Enums;

namespace Keyify.Domain.Tunings.Bass
{
    public class StandardBassTuning : Tuning
    {
        private readonly Note[] _notes = new Note[4]
        {
            Note.E,
            Note.A,
            Note.D,
            Note.G
        };

        public override Note[] Notes => _notes;

        public override int StringCount => _notes.Length;
    }
}
