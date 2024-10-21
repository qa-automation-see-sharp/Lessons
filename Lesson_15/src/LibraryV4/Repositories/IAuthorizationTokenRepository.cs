using LibraryV4.Contracts.Dto;

namespace LibraryV4.Repositories;

public interface IAuthorizationTokenRepository
{
    public Task<AuthorizationTokenDto?> GetTokenByUserId(Guid userId);

    public Task<AuthorizationTokenDto?> GetToken(string token);

    public Task AddToken(AuthorizationTokenDto token);
    public Task<bool> DeleteToken(Guid userId);
}