using Keyify.Database.RecordCreation.Factories.Abstraction;
using Keyify.Infrastructure.Repository;
using Keyify.MusicTheory.Definitions;
using Keyify.MusicTheory.Enums;
using Keyify.Web.Infrastructure.Models.ChordDefinition;
using Keyify.Web.Infrastructure.Repository.Interfaces;

namespace Keyify.Database.RecordCreation.Factories
{
    internal class ChordDefinitionCreationFactory : DatabaseRecordFactory
    {
        private Dictionary<ChordType, Interval[]> _chordDefinitions;
        private IChordDefinitionRepository _chordDefinitionRepository;

        internal ChordDefinitionCreationFactory(string connectionString) : base(connectionString)
        {
            _chordDefinitions = ChordDefinitions.GenerateChordDefinitions();
            _chordDefinitionRepository = new ChordDefinitionRepository(connectionString);
        }

        internal override async Task Execute()
        {
            foreach (var chordDefinition in _chordDefinitions)
            {
                await _chordDefinitionRepository.InsertChordDefinition(new ChordDefinitionRequest() { Name = chordDefinition.Key.ToString(), Intervals = chordDefinition.Value });
            }
        }
    }
}
