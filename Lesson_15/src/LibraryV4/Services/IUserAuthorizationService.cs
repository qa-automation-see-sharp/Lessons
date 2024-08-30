using LibraryV4.Contracts.Domain;

namespace LibraryV4.Services;

public interface IUserAuthorizationService
{
    public Task<bool> IsAuthorizedByToken(string authorizationToken);
    public Task<bool> IsAuthorizedByNickName(string nickName);

    public Task<AuthorizationToken?> GenerateToken(Guid userId);

    public Task<AuthorizationToken?> GetToken(Guid userId);
}