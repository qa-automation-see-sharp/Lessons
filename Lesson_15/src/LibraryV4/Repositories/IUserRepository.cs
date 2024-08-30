using System.Linq.Expressions;
using LibraryV4.Contracts.Domain;
using LibraryV4.Contracts.Dto;

namespace LibraryV4.Repositories;

public interface IUserRepository
{
    public Task<UserDto?> GetUser(Expression<Func<UserDto, bool>> filter);
    public Task<bool> AddUser(User user);
}