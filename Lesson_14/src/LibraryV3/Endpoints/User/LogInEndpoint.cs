using LibraryV3.Contracts.Domain;
using LibraryV3.Repositories;
using LibraryV3.Services;

namespace LibraryV3.Endpoints.User;

public static class LogInEndpoint
{
    public const string Name = "LogIn";

    public static IEndpointRouteBuilder MapLogIn(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiEndpoints.Users.Login, (
                string nickName,
                string password,
                IUserRepository repository,
                IUserAuthorizationService tokenService) =>
            {
                var user = repository.GetUser(nickName);

                if (user == null || user.Password != password)
                {
                    return Results.BadRequest("Invalid nickname or password");
                }

                if (tokenService.IsAuthorizedByNickName(nickName))
                {
                    return Results.Ok(tokenService.GetToken(nickName));
                }

                var token = tokenService.GenerateToken(nickName, password);
                return Results.Ok(token);
            })
            .WithName(Name)
            .Produces<AuthorizationToken>()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);

        return app;
    }
}