using System.Text;
using LibraryV4.Contracts.Domain;
using Newtonsoft.Json;

namespace LibraryV4.Tests.Utils.Services.Http;

public class LibraryV4HttpService
{
    private readonly HttpClient _httpClient;
    public User User;
    public AuthorizationToken AuthorizationToken;


    public LibraryV4HttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        User = Helpers.DataHelper.CreateUser();
    }

    public async Task CreateDefaultUser()
    {
        var url = TestApiEndpoint.Users.Register;
        var json = JsonConvert.SerializeObject(User);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, content);
        LogResponse(response, url);
    }

    public async Task AuthorizeLikeDefaultUser()
    {
        var url = TestApiEndpoint.Users.Login(User.NickName, User.Password);
        var response = await _httpClient.GetAsync(url);
        LogResponse(response, url);

        var jsonString = await response.Content.ReadAsStringAsync();
        AuthorizationToken = JsonConvert.DeserializeObject<AuthorizationToken>(jsonString);
    }


    public async Task<HttpResponseMessage> CreateUser(User user)
    {
        var url = TestApiEndpoint.Users.Register;
        var json = JsonConvert.SerializeObject(user);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, content);
        LogResponse(response, url);

        return response;
    }

    public async Task<HttpResponseMessage> LogIn(User user)
    {
        var url = TestApiEndpoint.Users.Login(user.NickName, user.Password);
        var response = await _httpClient.GetAsync(url);
        LogResponse(response, url);

        return response;
    }


    public async Task<HttpResponseMessage> PostBook(string token, Book book)
    {
        var url = TestApiEndpoint.Books.Create(token);
        var json = JsonConvert.SerializeObject(book);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, content);
        LogResponse(response, url);

        return response;
    }

    public async Task<HttpResponseMessage> PostBook(Book book)
    {
        var url = TestApiEndpoint.Books.Create(AuthorizationToken.Token.ToString());
        var json = JsonConvert.SerializeObject(book);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, content);
        LogResponse(response, url);

        return response;
    }

    public async Task<HttpResponseMessage> GetBooksByTitle(string title)
    {
        var url = TestApiEndpoint.Books.GetBooksByTitle(title);
        var response = await _httpClient.GetAsync(url);
        LogResponse(response, url);

        return response;
    }

    public async Task<HttpResponseMessage> GetBooksByAuthor(string author)
    {
        var url = TestApiEndpoint.Books.GetBooksByAuthor(author);
        var response = await _httpClient.GetAsync(url);
        LogResponse(response, url);

        return response;
    }

    public async Task<HttpResponseMessage> DeleteBook(string title, string author)
    {
        var url = TestApiEndpoint.Books.Delete(title, author, AuthorizationToken.Token.ToString());
        var response = await _httpClient.DeleteAsync(url);
        LogResponse(response, url);

        return response;
    }

    private void LogResponse(HttpResponseMessage response, string url)
    {
        var jsonString = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine($"{response.RequestMessage.Method} request to:\n{_httpClient.BaseAddress}{url}");
        Console.WriteLine($"Response Status Code is: {response.StatusCode}");
        if (jsonString.Length > 0) Console.WriteLine($"Content: \n{jsonString}");
    }
}