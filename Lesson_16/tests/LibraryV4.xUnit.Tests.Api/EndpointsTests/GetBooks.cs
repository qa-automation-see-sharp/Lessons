using LibraryV4.Tests.Utils.Services.Http;
using LibraryV4.Tests.Utils.WebAppFactories;

namespace LibraryV4.xUnit.Tests.Api.EndpointsTests;

public class GetBooks : IAsyncLifetime, IClassFixture<LibraryV4WebAppFactory>, IClassFixture<LibraryV4HttpService>
{
    private readonly LibraryV4WebAppFactory _webAppFactory;
    private readonly LibraryV4HttpService _httpService;

    public GetBooks(LibraryV4WebAppFactory webAppFactory, LibraryV4HttpService httpService)
    {
        _webAppFactory = webAppFactory;
        _httpService = httpService;
    }

    [Fact]
    public async Task Test1()
    {
    }

    public Task InitializeAsync()
    {
        throw new NotImplementedException();
    }

    public Task DisposeAsync()
    {
        throw new NotImplementedException();
    }
}