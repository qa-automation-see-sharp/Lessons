using LibraryV4.Contracts.Domain;
using LibraryV4.Contracts.Mappings;
using LibraryV4.Repositories;
using LibraryV4.Services;

namespace LibraryV4.Endpoints.Books;

public static class CreateBookEndpoint
{
    public const string Name = "CreateBook";

    public static IEndpointRouteBuilder MapCreateBook(this IEndpointRouteBuilder app)
    {
        app
            .MapPost(ApiEndpoints.Books.Create, async (
                string token,
                Book book,
                IBookRepository repository,
                IUserAuthorizationService service) =>
            {
                if (!await service.IsAuthorizedByToken(token)) return Results.Unauthorized();

                if (await repository.Exists(book))
                    return Results.BadRequest($"{book.Title} by {book.Author}, {book.YearOfRelease} already exists");

                await repository.AddBook(book.ToDto());

                return TypedResults.CreatedAtRoute(book, Name, new { title = book.Title });
            })
            .WithName(Name)
            .Produces<Book>()
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

        return app;
    }
}