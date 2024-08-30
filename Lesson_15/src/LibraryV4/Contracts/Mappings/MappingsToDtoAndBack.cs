using LibraryV4.Contracts.Domain;
using LibraryV4.Contracts.Dto;

namespace LibraryV4.Contracts.Mappings;

public static class MappingsToDtoAndBack
{
    public static User ToDomain(this UserDto dto)
    {
        return new User
        {
            FullName = dto.FullName,
            NickName = dto.NickName,
            Password = dto.Password
        };
    }

    public static UserDto ToDto(this User domain)
    {
        return new UserDto
        {
            Id = Guid.NewGuid(),
            FullName = domain.FullName,
            NickName = domain.NickName,
            Password = domain.Password
        };
    }

    public static AuthorizationToken ToDomain(this AuthorizationTokenDto dto)
    {
        return new AuthorizationToken
        {
            Token = Guid.Parse(dto.Token),
            ExpirationTime = dto.ExpirationTime
        };
    }

    public static AuthorizationTokenDto ToDto(this AuthorizationToken domain, Guid userId)
    {
        return new AuthorizationTokenDto
        {
            UserId = userId,
            Token = domain.Token.ToString(),
            ExpirationTime = domain.ExpirationTime,
        };
    }


    public static Book ToDomain(this BookDto dto)
    {
        return new Book
        {
            Title = dto.Title,
            Author = dto.Author,
            YearOfRelease = dto.YearOfRelease
        };
    }

    public static BookDto ToDto(this Book domain)
    {
        return new BookDto
        {
            Id = Guid.NewGuid(),
            Title = domain.Title,
            Author = domain.Author,
            YearOfRelease = domain.YearOfRelease
        };
    }
}