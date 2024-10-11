using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.PageObjects;

namespace Tests.NUnit.Ui.Tests;

[TestFixture]
public class LinksPageTests
{
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _linksPage = new LinksPage();
        _linksPage.OpenInBrowser(BrowserNames.Chrome);
        _linksPage.NavigateToPage();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _linksPage.Close();
    }

    private LinksPage _linksPage;

    [Test]
    public void ClickOnLinkThatOpensNewWindow()
    {
        var url = "https://demoqa.com/links";
        _linksPage.GoToHomePage();
        _linksPage.SwitchToTabByUrl(url);
        var currentUrl = _linksPage.GetPageUrl();
        Assert.That(currentUrl, Is.EqualTo(url));
    }
}