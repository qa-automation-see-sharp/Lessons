using static NUnit.Tests.UI.Fixtures.WebDriverFactory;

namespace NUnit.Tests.UI;

[TestFixture, Parallelizable(ParallelScope.All)]
public class FirstUiTests
{
    [Test]
    public async Task Test1()
    {
        var mainPaige = OpenGoogle();
        var firstSearchElement = mainPaige
            .Search("Selenium")
            .GetFirstElementInSearch();

        Assert.Multiple(() =>
        {
            Assert.That(firstSearchElement, Is.Not.Null);
            Assert.That(firstSearchElement.Text, Is.EqualTo("Selenium"));
        });
        mainPaige.BrowserQuit();
    }

    [Test]
    public async Task Test2()
    {
        await Task.Delay(100);
        var mainPaige = OpenGoogle();
        var firstSearchElement = mainPaige
            .Search("Selenium")
            .GetFirstElementInSearch();

        Assert.Multiple(() =>
        {
            Assert.That(firstSearchElement, Is.Not.Null);
            Assert.That(firstSearchElement.Text, Is.EqualTo("Selenium"));
        });
        mainPaige.BrowserQuit();
    }
}