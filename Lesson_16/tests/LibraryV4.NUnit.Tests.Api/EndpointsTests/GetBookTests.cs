using System.Net;
using LibraryV4.Contracts.Domain;
using LibraryV4.NUnit.Tests.Api.Fixtures;
using LibraryV4.Tests.Utils.Helpers;
using Newtonsoft.Json;

namespace LibraryV4.NUnit.Tests.Api.EndpointsTests;

public class GetBookTests : LibraryV4TestFixture
{
    [Test]
    public async Task Get_ExistingBook_ReturnsBook_CreateBookWithDb()
    {
        // Arrange
        //Create book with MongoDB
        var bookDto = DataHelper.CreateBookDto();
        await MongoDbService.Books.InsertItem(bookDto);
        
        // Act
        var getBookResponse = await LibraryHttpService.GetBooksByTitle(bookDto.Title);
        var jsonString = await getBookResponse.Content.ReadAsStringAsync();
        var books = JsonConvert.DeserializeObject<List<Book>>(jsonString);
        
        Assert.Multiple(() =>
        {
            //Assert.That(createBookResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(getBookResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(books[0].Title, Is.EqualTo(bookDto.Title));
            Assert.That(books[0].Author, Is.EqualTo(bookDto.Author));
            Assert.That(books[0].YearOfRelease, Is.EqualTo(bookDto.YearOfRelease));
        });
    }
    
    [Test]
    public async Task Get_ExistingBook_ReturnsBook_CreateBookWithHttp()
    {
        // Arrange
        
        //Create book with HTTP POST request
        var book = DataHelper.CreateBook();
        var createBookResponse = await LibraryHttpService.PostBook(book);
        
        // Act
        var getBookResponse = await LibraryHttpService.GetBooksByTitle(book.Title);
        var jsonString = await getBookResponse.Content.ReadAsStringAsync();
        var books = JsonConvert.DeserializeObject<List<Book>>(jsonString);
        
        Assert.Multiple(() =>
        {
            Assert.That(createBookResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(getBookResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(books[0].Title, Is.EqualTo(book.Title));
            Assert.That(books[0].Author, Is.EqualTo(book.Author));
            Assert.That(books[0].YearOfRelease, Is.EqualTo(book.YearOfRelease));
        });
    }
}