using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keyify.Infrastructure.Models.ChordDefinition
{
    //TODO: Remove this, and change js so that it uses int array
    public class ChordDefinitionCheckRequest
    {
        public string? Name { get; set; }
        public string? Intervals { get; set; }
    }
}
