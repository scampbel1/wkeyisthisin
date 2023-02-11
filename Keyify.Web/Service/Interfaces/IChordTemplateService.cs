using Keyify.Models.Service_Models;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;

namespace Keyify.Service.Interfaces
{
    public interface IChordTemplateService
    {
        public List<ChordTemplate> FindChordTemplates(Note[] notes);
    }
}
