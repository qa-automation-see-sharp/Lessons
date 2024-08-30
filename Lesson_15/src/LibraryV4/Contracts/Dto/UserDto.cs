using MongoDB.Bson.Serialization.Attributes;

namespace LibraryV4.Contracts.Dto;

public class UserDto
{
    [BsonId]
    public required Guid Id { get; init; }

    public required string FullName { get; init; } = default!;

    public required string NickName { get; init; } = default!;

    public required string Password { get; init; } = default!;
}