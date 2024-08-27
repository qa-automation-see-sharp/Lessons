using LibraryV3.Contracts.Domain;

namespace LibraryV3.Repositories;

public interface IUserRepository
{
    public User? GetUser(string nickName);
    public bool AddUser(User user);
}