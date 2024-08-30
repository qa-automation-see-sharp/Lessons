using MongoDB.Bson.Serialization.Attributes;

namespace LibraryV4.Contracts.Dto;

public class BookDto
{
    [BsonId]
    public required Guid Id { get; init; } = default!;

    public required string Title { get; init; } = default!;

    public required string Author { get; init; } = default!;

    public required int YearOfRelease { get; init; } = default!;
}