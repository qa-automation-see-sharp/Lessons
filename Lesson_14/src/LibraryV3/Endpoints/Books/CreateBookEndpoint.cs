
using LibraryV3.Contracts.Domain;
using LibraryV3.Repositories;
using LibraryV3.Services;

namespace LibraryV3.Endpoints.Books;

public static class CreateBookEndpoint
{
    public const string Name = "CreateBook";
    
    public static IEndpointRouteBuilder MapCreateBook(this IEndpointRouteBuilder app)
    {
        app
            .MapPost(ApiEndpoints.Books.Create, (
                string token,
                Book book,
                IBookRepository repository,
                IUserAuthorizationService service) =>
            {
                if (!service.IsAuthorizedByToken(token)) return Results.Unauthorized();
                
                if (repository.Exists(book)) return Results.BadRequest($"{book.Title} by {book.Author}, {book.YearOfRelease} already exists");
                repository.AddBook(book);

                return TypedResults.CreatedAtRoute(book, Name, new { title = book.Title });
            })
            .WithName(Name)
            .Produces<Book>()
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

        return app;
    }
}