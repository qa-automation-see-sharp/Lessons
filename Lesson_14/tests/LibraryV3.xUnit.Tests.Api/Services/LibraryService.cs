using System.Text;
using LibraryV3.Contracts.Domain;
using LibraryV3.xUnit.Tests.Api.TestHelpers;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;

namespace LibraryV3.xUnit.Tests.Api.Services;

public class LibraryService : IAsyncLifetime
{
    private readonly HttpClient _httpClient;
    public User User;
    public AuthorizationToken AuthorizationToken;

    public LibraryService()
    {
        WebApplicationFactory<IApiMarker> factory = new();
        _httpClient = factory.CreateClient();
        User = DataHelper.CreateUser();
    }

    public void Configure(string baseUrl)
    {
        _httpClient.BaseAddress = new Uri(baseUrl);
    }

    public async Task CreateDefaultUser()
    {
        var url = TestApiEndpoint.Users.Register;

        var json = JsonConvert.SerializeObject(User);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, content);

        var jsonString = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"POST request to:\n{_httpClient.BaseAddress}{url}");
        Console.WriteLine($"Response Status Code is: {response.StatusCode}");
        Console.WriteLine($"Content: \n{jsonString}");
    }

    public async Task AuthorizeLikeDefaultUser()
    {
        var url = TestApiEndpoint.Users.Login(User.NickName, User.Password);

        var response = await _httpClient.GetAsync(url);
        var jsonString = await response.Content.ReadAsStringAsync();

        AuthorizationToken = JsonConvert.DeserializeObject<AuthorizationToken>(jsonString);

        Console.WriteLine($"Authorized with user:\n{jsonString}");
    }


    public async Task<HttpResponseMessage> CreateUser(User user)
    {
        var url = TestApiEndpoint.Users.Register;

        //RequestBody creation
        var json = JsonConvert.SerializeObject(user);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(url, content);
        var jsonString = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"POST request to:\n{_httpClient.BaseAddress}{url}");
        Console.WriteLine($"Response Status Code is: {response.StatusCode}");
        Console.WriteLine($"Content: \n{jsonString}");

        return response;
    }

    public async Task<HttpResponseMessage> LogIn(User user)
    {
        var url = TestApiEndpoint.Users.Login(user.NickName, user.Password);

        var response = await _httpClient.GetAsync(url);
        var jsonString = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"Authorized with user:\n{jsonString}");

        return response;
    }

    public async Task<HttpResponseMessage> CreateBook(string token, Book book)
    {
        var url = TestApiEndpoint.Books.Create(token);

        var json = JsonConvert.SerializeObject(book);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, content);
        var jsonString = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"POST request to:\n{_httpClient.BaseAddress}{url}");
        Console.WriteLine($"Response Status Code is: {response.StatusCode}");
        Console.WriteLine($"Content: \n{jsonString}");

        return response;
    }

    public async Task<HttpResponseMessage> CreateBook(Book book)
    {
        var url = TestApiEndpoint.Books.Create(AuthorizationToken.Token!);

        var json = JsonConvert.SerializeObject(book);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, content);
        var jsonString = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"POST request to:\n{_httpClient.BaseAddress}{url}");
        Console.WriteLine($"Response Status Code is: {response.StatusCode}");
        Console.WriteLine($"Content: \n{jsonString}");

        return response;
    }

    public async Task<HttpResponseMessage> GetBooksByTitle(string title)
    {
        var url = TestApiEndpoint.Books.GetBooksByTitle(title);

        var response = await _httpClient.GetAsync(url);
        var jsonString = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"GET request to:\n{_httpClient.BaseAddress}{url}");
        Console.WriteLine($"Response Status Code is: {response.StatusCode}");
        Console.WriteLine($"Content: \n{jsonString}");

        return response;
    }

    public async Task<HttpResponseMessage> GetBooksByAuthor(string author)
    {
        var url = TestApiEndpoint.Books.GetBooksByAuthor(author);

        var response = await _httpClient.GetAsync(url);
        var jsonString = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"GET request to:\n{_httpClient.BaseAddress}{url}");
        Console.WriteLine($"Response Status Code is: {response.StatusCode}");
        Console.WriteLine($"Content: \n{jsonString}");

        return response;
    }

    public async Task<HttpResponseMessage> DeleteBook(string title, string author)
    {
        var url = TestApiEndpoint.Books.Delete(title, author, AuthorizationToken.Token);

        var response = await _httpClient.DeleteAsync(url);
        var jsonString = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"DELETE request to:\n{_httpClient.BaseAddress}{url}");
        Console.WriteLine($"Response Status Code is: {response.StatusCode}");
        Console.WriteLine($"Content: \n{jsonString}");

        return response;
    }

    public async Task InitializeAsync()
    {
       Console.WriteLine("Set Up from LibraryService");
    }

    public async Task DisposeAsync()
    {
        Console.WriteLine("Tear Down from LibraryService");
    }
}