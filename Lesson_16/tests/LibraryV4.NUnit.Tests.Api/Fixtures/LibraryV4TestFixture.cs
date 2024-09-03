using LibraryV4.Tests.Utils.Services.Database;
using LibraryV4.Tests.Utils.Services.Http;
using LibraryV4.Tests.Utils.WebAppFactories;

namespace LibraryV4.NUnit.Tests.Api.Fixtures;

[TestFixture]
public class LibraryV4TestFixture
{
    private LibraryV4WebAppFactory _webAppFactory;
    protected LibraryV4HttpService LibraryHttpService;
    protected MongoDbService MongoDbService;

    [OneTimeSetUp]
    public async Task OneTimeSetUp()
    {
        //Creating an WebFactory instance
        _webAppFactory = new LibraryV4WebAppFactory();
        //Starting MongoDb in DOcker
        await _webAppFactory.StartMongo();
        //Creating an HttpClient instance
        var httpClient = _webAppFactory.CreateClient();
        //Creating an instance of LibraryHttpService
        LibraryHttpService = new LibraryV4HttpService(httpClient);
        //Creating an instance of MongoDbService
        MongoDbService = new MongoDbService(_webAppFactory.MongoDbContainer.GetConnectionString(), "LibraryV4");
        //Creating a default user
        await LibraryHttpService.CreateDefaultUser();
        await LibraryHttpService.AuthorizeLikeDefaultUser();
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDown()
    {
        await _webAppFactory.StopMongo();
    }
}