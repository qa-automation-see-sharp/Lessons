using System.Linq.Expressions;
using MongoDB.Driver;

namespace LibraryV4.Tests.Utils.Services.Database;

public class MongoDbCollection<T>
{
    private readonly IMongoCollection<T> _collection;

    public MongoDbCollection(IMongoDatabase client, string collectionName)
    {
        _collection = client.GetCollection<T>(collectionName);
    }
    
    public async Task<T?> InsertItem(T item)
    {
        try
        {
            await _collection.InsertOneAsync(item);
        }
        catch (MongoException e)
        {
            Console.WriteLine(e);
        }

        return item;
    }
    public async Task<T?> GetItem(Expression<Func<T, bool>> filter)
    {
        T? item = default;
        try
        {
            item = await _collection
                .Find(filter)
                .FirstOrDefaultAsync();
        }
        catch (MongoException e)
        {
            Console.WriteLine(e);
        }

        return item;
    }
    public async Task<List<T>?> GetItems(Expression<Func<T, bool>> filter)
    {
        List<T>? item = default;
        try
        {
            item = await _collection
                .Find(filter)
                .ToListAsync();
        }
        catch (MongoException e)
        {
            Console.WriteLine(e);
        }

        return item;
    }
    public async Task<bool> DeleteItem(Expression<Func<T, bool>> filter)
    {
        try
        {
            await _collection.DeleteOneAsync(filter);
        }
        catch (MongoException e)
        {
            Console.WriteLine(e);
            return false;
        }

        return true;
    }
}