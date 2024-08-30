using MongoDB.Driver;

namespace LibraryV4.Database;

public interface IMongoDbConnectionFactory
{
    IMongoDatabase GetDatabase();
}