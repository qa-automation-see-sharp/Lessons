using Bogus;
using LibraryV4.Contracts.Domain;
using LibraryV4.Contracts.Dto;

namespace LibraryV4.Tests.Utils.Helpers;

//Here we are using Bogus library to generate fake data
public static class DataHelper
{
    public static Book CreateBook()
    {
        return new Faker<Book>()
            // Setting up rules for generating fake data for each property of the Book class
            .RuleFor(o => o.Author, f => f.Person.FullName)
            .RuleFor(o => o.Title, f => f.Random.Words(2))
            .RuleFor(o => o.YearOfRelease, f => f.Random.Number(1850, 2024))
            .Generate();
    }

    public static BookDto CreateBookDto()
    {
        return new Faker<BookDto>()
            // Setting up rules for generating fake data for each property of the BookDto class
            .RuleFor(o => o.Id, f => f.Random.Guid())
            .RuleFor(o => o.Author, f => f.Person.FullName)
            .RuleFor(o => o.Title, f => f.Random.Words(2))
            .RuleFor(o => o.YearOfRelease, f => f.Random.Number(1850, 2024))
            .Generate();
    }

    public static User CreateUser()
    {
        return new Faker<User>()
            // Setting up rules for generating fake data for each property of the User class
            .RuleFor(o => o.NickName, f => f.Person.UserName)
            .RuleFor(o => o.FullName, f => f.Person.FullName)
            .RuleFor(o => o.Password, f => f.Internet.Password())
            .Generate();
    }

    public static UserDto CreateUserDto()
    {
        return new Faker<UserDto>()
            // Setting up rules for generating fake data for each property of the UserDto class
            .RuleFor(o => o.Id, f => f.Random.Guid())
            .RuleFor(o => o.NickName, f => f.Person.UserName)
            .RuleFor(o => o.FullName, f => f.Person.FullName)
            .RuleFor(o => o.Password, f => f.Internet.Password())
            .Generate();
    }
}