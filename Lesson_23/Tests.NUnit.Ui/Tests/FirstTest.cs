using Tests.NUnit.Ui.PageObjects;
using Tests.Utils.Swd.Browser;

namespace Tests.NUnit.Ui.Tests;

[TestFixture, Parallelizable(ParallelScope.All)]
public class FirstTest
{
    private MainPage _mainPage;

    [SetUp]
    public void SetUp()
    {
        _mainPage = new MainPage();
        _mainPage.OpenWith(BrowserNames.Chrome, "--start-maximized");
    }

    [Test]
    public void Test()
    {
        // Act
        var title = _mainPage.Open().GetPageTitle();
        var elements = _mainPage.GoToCardWithText("Elements");

        // Assert
        Assert.Multiple(() => { Assert.That(title, Is.EqualTo("DEMOQA")); });
    }

    [Test]
    public void Test2()
    {
        // Act
        var title = _mainPage.Open().GetPageTitle();
        var elements = _mainPage.GoToCardWithText("Elements");

        // Assert
        Assert.Multiple(() => { Assert.That(title, Is.EqualTo("DEMOQA")); });
    }

    [TearDown]
    public void TearDown()
    {
        _mainPage!.Close();
    }
}