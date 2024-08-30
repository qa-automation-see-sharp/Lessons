using System.Linq.Expressions;
using LibraryV4.Contracts.Domain;
using LibraryV4.Contracts.Dto;
using LibraryV4.Database;
using MongoDB.Driver;

namespace LibraryV4.Repositories;

public class BookRepository : IBookRepository
{
    private const string CollectionName = "books";
    private readonly ILogger<BookRepository> _logger;
    private readonly IMongoCollection<BookDto> _collection;

    public BookRepository(
        ILogger<BookRepository> logger,
        IMongoDbConnectionFactory connectionFactory)
    {
        _logger = logger;
        _collection = connectionFactory
            .GetDatabase()
            .GetCollection<BookDto>(CollectionName);
    }

    public async Task AddBook(BookDto book)
    {
        try
        {
            var bookDto = await _collection
                .Find(b => b.Title == book.Title &&
                           b.Author == book.Author &&
                           b.YearOfRelease == book.YearOfRelease)
                .FirstOrDefaultAsync();

            if (bookDto is not null)
            {
                _logger.LogWarning("Book with title {title} already exists", book.Title);
            }
            else
            {
                await _collection.InsertOneAsync(book);
            }
        }
        catch (MongoException e)
        {
            _logger.LogError(e, "InnerError is {inner}", e.InnerException);
        }
    }

    public async Task<BookDto?> GetBook(Expression<Func<BookDto, bool>> filter)
    {
        BookDto? bookDto = null;
        try
        {
            bookDto = await _collection
                .Find(filter)
                .FirstOrDefaultAsync();
        }
        catch (MongoException e)
        {
            _logger.LogError(e, "InnerError is {inner}", e.InnerException);
        }

        return bookDto;
    }


    public async Task<List<BookDto>> GetMany(Expression<Func<BookDto, bool>> filter)
    {
        List<BookDto> books = new();
        try
        {
            books = await _collection
                .Find(filter)
                .ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "InnerError is {inner}", e.InnerException);
        }

        return books;
    }

    public async Task<bool> Delete(FilterDefinition<BookDto> filterDefinition)
    {
        var bookToRemove = await _collection.DeleteOneAsync(filterDefinition);
        return bookToRemove.IsAcknowledged;
    }

    public async Task<bool> Exists(Book book)
    {
        var bookDto = await _collection
            .Find(b => b.Title == book.Title &&
                       b.Author == book.Author &&
                       b.YearOfRelease == book.YearOfRelease)
            .FirstOrDefaultAsync();

        return bookDto is not null;
    }
}