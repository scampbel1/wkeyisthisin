namespace Keyify.Database.RecordCreation.Factory.Abstraction
{
    internal abstract class DatabaseRecordCreator
    {
        internal readonly string ConnectionString;

        internal DatabaseRecordCreator(string connectionString)
        {
            ConnectionString = connectionString;
        }

        internal abstract Task ExecuteAsync();
    }
}
