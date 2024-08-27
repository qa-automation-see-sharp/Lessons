namespace LibraryV3.Contracts.Domain;

public class AuthorizationToken
{
    public string? Token { get; set; }
    public string? NickName { get; set; }
    public DateTime? ExpirationTime { get; set; }
}