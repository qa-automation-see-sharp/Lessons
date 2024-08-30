using LibraryV4.Contracts.Domain;
using LibraryV4.Contracts.Mappings;
using LibraryV4.Repositories;

namespace LibraryV4.Services;

public class UserAuthorizationService : IUserAuthorizationService
{
    private readonly ILogger<UserAuthorizationService> _logger;
    private readonly IUserRepository _userRepository;
    private readonly IAuthorizationTokenRepository _authorizationTokenRepository;


    public UserAuthorizationService(
        ILogger<UserAuthorizationService> logger,
        IUserRepository userRepository,
        IAuthorizationTokenRepository authorizationTokenRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
        _authorizationTokenRepository = authorizationTokenRepository;
    }

    public async Task<bool> IsAuthorizedByToken(string authorizationToken)
    {
        var token = await _authorizationTokenRepository.GetToken(authorizationToken);
        var user = await _userRepository.GetUser(u => u.Id == token.UserId);

        if (token is null) return false;
        if (token.ExpirationTime <= DateTime.Now) return false;

        _logger.Log(LogLevel.Debug, $"User {user.NickName} is authorized.");

        return true;
    }

    public async Task<bool> IsAuthorizedByNickName(string nickName)
    {
        var user = await _userRepository.GetUser(u => u.NickName == nickName);
        var token = await _authorizationTokenRepository.GetTokenByUserId(user.Id);

        if (token is null) return false;
        if (token.ExpirationTime <= DateTime.Now) return false;

        _logger.Log(LogLevel.Debug, $"User {user.NickName} is authorized.");

        return true;
    }

    public async Task<AuthorizationToken?> GenerateToken(Guid userId)
    {
        var tmp = await _authorizationTokenRepository.GetTokenByUserId(userId);

        if (tmp is not null)
        {
            await _authorizationTokenRepository.DeleteToken(userId);
        }

        var token = new AuthorizationToken
        {
            Token = Guid.NewGuid(),
            ExpirationTime = DateTime.Now.AddMinutes(15)
        };

        await _authorizationTokenRepository.AddToken(token.ToDto(userId));

        _logger.Log(LogLevel.Debug, $"Token for user {userId} generated.");

        return token;
    }

    public async Task<AuthorizationToken?> GetToken(Guid userId)
    {
        var token = await _authorizationTokenRepository.GetTokenByUserId(userId);

        return token?.ToDomain();
    }
}