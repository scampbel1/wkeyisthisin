namespace Keyify.Database.RecordCreation.Factories.Abstraction
{
    internal abstract class DatabaseRecordFactory
    {
        internal readonly string ConnectionString;

        internal DatabaseRecordFactory(string connectionString)
        {
            ConnectionString = connectionString;
        }

        internal abstract Task Execute();
    }
}
