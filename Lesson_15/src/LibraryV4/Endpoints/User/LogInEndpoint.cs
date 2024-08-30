using LibraryV4.Contracts.Domain;
using LibraryV4.Contracts.Mappings;
using LibraryV4.Repositories;
using LibraryV4.Services;

namespace LibraryV4.Endpoints.User;

public static class LogInEndpoint
{
    public const string Name = "LogIn";

    public static IEndpointRouteBuilder MapLogIn(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiEndpoints.Users.Login, async (
                string nickName,
                string password,
                IUserRepository repository,
                IUserAuthorizationService tokenService) =>
            {
                var userDto = await repository.GetUser(u => u.NickName == nickName);
                var user = userDto?.ToDomain();

                if (user == null || user.Password != password)
                {
                    return Results.BadRequest("Invalid nickname or password");
                }

                if (await tokenService.IsAuthorizedByNickName(nickName))
                {
                    return Results.Ok(tokenService.GetToken(userDto.Id));
                }

                var token = await tokenService.GenerateToken(userDto.Id);

                return Results.Ok(token);
            })
            .WithName(Name)
            .Produces<AuthorizationToken>()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);

        return app;
    }
}