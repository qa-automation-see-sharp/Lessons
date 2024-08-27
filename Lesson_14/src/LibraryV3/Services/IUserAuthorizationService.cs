using LibraryV3.Contracts.Domain;

namespace LibraryV3.Services;

public interface IUserAuthorizationService
{
    public bool IsAuthorizedByToken(string authorizationToken);
    public bool IsAuthorizedByNickName(string nickName);

    public AuthorizationToken? GenerateToken(string nickName, string password);

    public AuthorizationToken? GetToken(string nickName);
}