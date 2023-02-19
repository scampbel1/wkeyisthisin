using Keyify.MusicTheory.Enums;

namespace Keyify.Web.Models.Tunings
{
    public abstract class Tuning
    {
        public abstract Note[] Notes { get; }
        public abstract int StringCount { get; }
    }
}