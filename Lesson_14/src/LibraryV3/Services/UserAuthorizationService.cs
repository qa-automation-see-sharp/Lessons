using LibraryV3.Contracts.Domain;
using LibraryV3.Repositories;

namespace LibraryV3.Services;

public class UserAuthorizationService : IUserAuthorizationService
{
    private readonly IUserRepository _userRepository;
    private readonly List<AuthorizationToken> _tokens = new();
    private readonly ILogger<UserAuthorizationService> _logger;

    public UserAuthorizationService(IUserRepository userRepository, ILogger<UserAuthorizationService> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public bool IsAuthorizedByToken(string authorizationToken)
    {
        var token = _tokens.FirstOrDefault(t => t.Token == authorizationToken);

        if (token is not null)
        {
            if (token.ExpirationTime > DateTime.Now)
            {
                _logger.Log(LogLevel.Debug, $"User {token.NickName} is authorized.");
                return true;
            }
        }

        return false;
    }

    public bool IsAuthorizedByNickName(string nickName)
    {
        var token = _tokens.FirstOrDefault(t => t.NickName == nickName);

        if (token is not null)
        {
            if (token.ExpirationTime > DateTime.Now)
            {
                _logger.Log(LogLevel.Debug, $"User {token.NickName} is authorized.");
                return true;
            }
        }

        return false;
    }

    public AuthorizationToken? GenerateToken(string nickName, string password)
    {
        var user = _userRepository.GetUser(nickName);

        if (user == null || user.Password != password)
        {
            _logger.Log(LogLevel.Debug, $"User with nickname {user.NickName} doesnt exist or password is incorrect.");
            return null;
        }

        var tmp = _tokens.FirstOrDefault(t => t.NickName == nickName);
        if (tmp is not null)
        {
            _tokens.Remove(tmp);
        }

        var token = new AuthorizationToken
        {
            Token = Guid.NewGuid().ToString(),
            NickName = nickName,
            ExpirationTime = DateTime.Now.AddMinutes(15)
        };

        _tokens.Add(token);
        _logger.Log(LogLevel.Debug, $"Token for user {token.NickName} generated.");
        return token;
    }

    public AuthorizationToken? GetToken(string nickName)
    {
        return _tokens.FirstOrDefault(t => t.NickName == nickName);
    }
}