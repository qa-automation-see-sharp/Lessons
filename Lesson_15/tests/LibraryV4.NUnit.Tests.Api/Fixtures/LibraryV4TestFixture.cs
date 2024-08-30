using Microsoft.AspNetCore.Mvc.Testing;

namespace LibraryV4.NUnit.Tests.Api.Fixtures;

[TestFixture]
public class LibraryV4TestFixture
{
    public WebApplicationFactory<IApiMarker> WebAppFactory;

    [OneTimeSetUp]
    public void TaskOneTimeSetUp()
    {
        WebAppFactory = new WebApplicationFactory<IApiMarker>();
    }
}