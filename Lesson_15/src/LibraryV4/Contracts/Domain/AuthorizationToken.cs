namespace LibraryV4.Contracts.Domain;

public class AuthorizationToken
{
    public Guid Token { get; init; }
    public DateTime? ExpirationTime { get; init; }
}