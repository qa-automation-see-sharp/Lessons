using System.Linq.Expressions;
using LibraryV4.Contracts.Domain;
using LibraryV4.Contracts.Dto;
using LibraryV4.Contracts.Mappings;
using LibraryV4.Database;
using MongoDB.Driver;

namespace LibraryV4.Repositories;

public class UserRepository : IUserRepository
{
    private const string CollectionName = "users";
    private readonly ILogger<UserRepository> _logger;
    private readonly IMongoCollection<UserDto> _collection;

    public UserRepository(
        ILogger<UserRepository> logger,
        IMongoDbConnectionFactory connectionFactory)
    {
        _logger = logger;
        _collection = connectionFactory
            .GetDatabase()
            .GetCollection<UserDto>(CollectionName);
    }

    public async Task<UserDto?> GetUser(Expression<Func<UserDto, bool>> filter)
    {
        UserDto? userDto = null;
        try
        {
            userDto = await _collection
                .Find(filter)
                .FirstOrDefaultAsync();
        }
        catch (MongoException e)
        {
            _logger.LogError(e, "InnerError is {inner}", e.InnerException);
        }

        return userDto;
    }

    public async Task<bool> AddUser(User user)
    {
        try
        {
            var userDto = await _collection
                .Find(u => u.NickName == user.NickName)
                .FirstOrDefaultAsync();

            if (userDto != null) return false;

            await _collection.InsertOneAsync(user.ToDto());
        }
        catch (MongoException e)
        {
            _logger.LogError(e, "InnerError is {inner}", e.InnerException);
        }

        return true;
    }
}