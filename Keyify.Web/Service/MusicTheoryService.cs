using Keyify.Models.Service;
using Keyify.Models.Service_Models;
using Keyify.Service.Interfaces;
using Keyify.Web.Service.Interfaces;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Web.Service
{
    public class MusicTheoryService : IMusicTheoryService
    {
        private readonly IScaleService _scaleService;
        private readonly IChordTemplateService _chordTemplateSerice;

        public MusicTheoryService(IScaleService scaleService, IChordTemplateService chordTemplateSerice)
        {
            _scaleService = scaleService;
            _chordTemplateSerice = chordTemplateSerice;
        }

        public IEnumerable<ScaleEntry> FindScales(IEnumerable<Note> selectedNotes)
        {
            var minimumNoteSelectionCount = 2;

            return selectedNotes.Count() > minimumNoteSelectionCount ? _scaleService.FindScales(selectedNotes) : null;
        }

        public IEnumerable<ChordTemplate> GetChordsTemplates(string selectedScale, Note[] selectedNotes)
        {
            //TODO: Implement logic for deciding whether to get chords by notes or scale
            return _chordTemplateSerice.FindChordTemplateWithNoteSequence(selectedNotes);
        }
    }
}
