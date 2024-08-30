using LibraryV4.Repositories;

namespace LibraryV4.Endpoints.User;

public static class CreateUserEndpoint
{
    public const string Name = "CreateUser";

    public static IEndpointRouteBuilder MapCreateUser(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiEndpoints.Users.Register, async (
            Contracts.Domain.User user,
            IUserRepository repository) =>
        {
            if (await repository.GetUser(u => u.NickName == user.NickName) is not null)
            {
                return Results.BadRequest($"User with nickname {user.NickName} already exists");
            }

            await repository.AddUser(user);

            return Results.Created(ApiEndpoints.Users.Register, new { nickName = user.NickName , fullName = user.FullName});
            })
            .WithName(Name)
            .Produces<Contracts.Domain.User>()
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status404NotFound);

        return app;
    }
}