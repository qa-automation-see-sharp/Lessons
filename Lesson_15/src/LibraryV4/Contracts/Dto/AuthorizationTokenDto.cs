using MongoDB.Bson.Serialization.Attributes;

namespace LibraryV4.Contracts.Dto;

public class AuthorizationTokenDto
{
    [BsonId]
    public required Guid UserId { get; init; }
    
    public required string Token { get; init; }
    public required DateTime? ExpirationTime { get; init; }
}