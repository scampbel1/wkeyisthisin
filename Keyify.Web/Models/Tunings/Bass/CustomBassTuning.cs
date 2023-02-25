using Keyify.MusicTheory.Enums;
using Keyify.Web.Models.Tunings;
using System;

namespace Keyify.Models.Tunings.Bass
{
    public class CustomBassTuning : Tuning
    {
        private readonly Note[] _notes;

        public CustomBassTuning(Note[] notes)
        {
            _notes = notes;
        }

        public override Note[] Notes => throw new NotImplementedException();

        public override int StringCount => throw new NotImplementedException();
    }
}