using LibraryV4.Contracts.Dto;
using MongoDB.Driver;

namespace LibraryV4.Tests.Utils.Services.Database;

public class MongoDbService
{
    public readonly MongoDbCollection<UserDto> Users;
    public readonly MongoDbCollection<BookDto> Books;
    public readonly MongoDbCollection<AuthorizationTokenDto> Tokens;

    public MongoDbService(string connectionString, string dbName)
    {
        var mongoClient = new MongoClient(connectionString);
        Users = new MongoDbCollection<UserDto>(mongoClient.GetDatabase(dbName), "users");
        Books = new MongoDbCollection<BookDto>(mongoClient.GetDatabase(dbName), "books");
        Tokens = new MongoDbCollection<AuthorizationTokenDto>(mongoClient.GetDatabase(dbName), "authorizationTokens");
    }
}