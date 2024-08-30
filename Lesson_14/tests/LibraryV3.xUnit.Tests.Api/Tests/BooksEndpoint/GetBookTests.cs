using LibraryV3.Contracts.Domain;
using LibraryV3.xUnit.Tests.Api.Services;
using LibraryV3.xUnit.Tests.Api.TestHelpers;
using Newtonsoft.Json;

namespace LibraryV3.xUnit.Tests.Api.Tests.BooksEndpoint;

public class GetBookTests : IAsyncLifetime, IClassFixture<LibraryService>
{
    private readonly LibraryService _libraryService;
    private Book _book;

    //[SetUp] #1
    public GetBookTests(LibraryService libraryService)
    {
        _libraryService = libraryService;
    }
    
    //[SetUp] #2
    public async Task InitializeAsync()
    {
        //Arrange
        await _libraryService.CreateDefaultUser();
        await _libraryService.AuthorizeLikeDefaultUser();
        _book = DataHelper.CreateBook();
        await _libraryService.CreateBook(_book);
    }
    

    [Fact]
    public async Task GetBooksByTitle_ExistingBook_ReturnsOk()
    {
        // Act
        var book = await _libraryService.GetBooksByTitle(_book.Title);
        var booksJsonString = await book.Content.ReadAsStringAsync();
        var books = JsonConvert.DeserializeObject<List<Book>>(booksJsonString);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.NotNull(books);
            Assert.NotEmpty(books);
            Assert.Single(books);
            Assert.Equal(books[0].Title, _book.Title);
            Assert.Equal(books[0].Author, _book.Author);
            Assert.Equal(books[0].YearOfRelease, _book.YearOfRelease);
        });
    }

    [Fact]
    public async Task GetBooksByAuthor_ExistingBook_ReturnsOk()
    {
        // Arrange

        // Act
        var book = await _libraryService.GetBooksByAuthor(_book.Author);
        var booksJsonString = await book.Content.ReadAsStringAsync();
        var books = JsonConvert.DeserializeObject<List<Book>>(booksJsonString);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.NotNull(books);
            Assert.NotEmpty(books);
            Assert.Single(books);
            Assert.Equal(books[0].Title, _book.Title);
            Assert.Equal(books[0].Author, _book.Author);
            Assert.Equal(books[0].YearOfRelease, _book.YearOfRelease);
        });
    }

    //[TearDown]
    public async Task DisposeAsync()
    {
        await _libraryService.DeleteBook(_book.Title, _book.Author);
    }
}