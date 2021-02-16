using KeyifyClassLibrary.Core.Domain;
using System.Collections.Generic;

namespace Keyify.Models
{
    public interface IScaleListService
    {
        List<ScaleListEntry> GetScaleList();        
    }
}
