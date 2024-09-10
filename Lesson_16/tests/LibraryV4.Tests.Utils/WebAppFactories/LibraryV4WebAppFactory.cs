using DotNet.Testcontainers.Builders;
using LibraryV4.Database;
using LibraryV4.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Testcontainers.MongoDb;

namespace LibraryV4.Tests.Utils.WebAppFactories;

public class LibraryV4WebAppFactory : WebApplicationFactory<IApiMarker>
{
    public readonly MongoDbContainer MongoDbContainer =
        new MongoDbBuilder()
            .WithPortBinding(27017, 27017)
            .WithName("LibraryDb")
            .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(27017))
            .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(IMongoDbConnectionFactory));
            services.AddSingleton<IMongoDbConnectionFactory>(_ => new MongoDbFactory(GetMongoDbOptions()));
        });
    }

    public async Task StartMongo()
    {
        await MongoDbContainer.StartAsync();
    }

    public async Task StopMongo()
    {
        await MongoDbContainer.StopAsync();
        await MongoDbContainer.DisposeAsync();
    }

    private IOptions<MongoDbOptions> GetMongoDbOptions()
    {
        return new OptionsWrapper<MongoDbOptions>(new MongoDbOptions
        {
            ConnectionString = MongoDbContainer.GetConnectionString(),
            DbName = "LibraryV4"
        });
    }
}