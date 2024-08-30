using System.Linq.Expressions;
using LibraryV4.Contracts.Domain;
using LibraryV4.Contracts.Dto;
using MongoDB.Driver;

namespace LibraryV4.Repositories;

public interface IBookRepository
{
    public Task AddBook(BookDto book);
    public Task<BookDto?> GetBook(Expression<Func<BookDto, bool>> filter);
    public Task<List<BookDto>> GetMany(Expression<Func<BookDto, bool>> filter);
    public Task<bool> Delete(FilterDefinition<BookDto> filterDefinition);
    public Task<bool> Exists(Book book);
}