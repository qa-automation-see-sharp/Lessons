using Tests.NUnit.Ui.PageObjects;
using static Test.Utils.Swd.WebDriverFactory.BrowserNames;

namespace Tests.NUnit.Ui.Tests;

[TestFixture]
public class TextBoxTests
{
    private MainPage _mainPage;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _mainPage = new MainPage();
        _mainPage.Open(Chrome, "--start-maximized");
    }

    [Test]
    public void FirstTest()
    {
        var title = _mainPage.GetPageTitle();
        var elementsPage = _mainPage.ClickOnElements();

        Assert.Multiple(() =>
        {
            Assert.That(title, Is.EqualTo("DEMOQA"));
        });
    }
    
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _mainPage.Close();
    }
}