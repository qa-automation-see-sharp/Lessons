using LibraryV3.Contracts.Domain;
using LibraryV3.Repositories;

namespace LibraryV3.Endpoints.Books;

public static class GetBookEndpoints
{
    public const string Name = "GetBooksByTitle";
    public const string GetAllBooksByAuthor = "GetBooksByAuthor";

    public static IEndpointRouteBuilder MapGetBooksByTitle(this IEndpointRouteBuilder app)
    {
        app
            .MapGet(ApiEndpoints.Books.GetBooksByTitle, (
                string title,
                IBookRepository repository) =>
            {
                var result = repository.GetMany(b => b.Title == title);

                return result.Count is 0
                    ? Results.NotFound($"The books this title: {title}, was not found.")
                    : Results.Ok(result);
            })
            .WithName(Name)
            .Produces<List<Book>>()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status401Unauthorized);

        return app;
    }

    public static IEndpointRouteBuilder MapGetBooksByAuthor(this IEndpointRouteBuilder app)
    {
        app
            .MapGet(ApiEndpoints.Books.GetBooksByAuthor, (
                string author,
                IBookRepository repository) =>
            {
                var result = repository.GetMany(b => b.Author == author);

                return result.Count is 0
                    ? Results.NotFound($"The books by author: {author}, was not found.")
                    : Results.Ok(result);
            })
            .WithName(GetAllBooksByAuthor)
            .Produces<List<Book>>()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status401Unauthorized);

        return app;
    }
}