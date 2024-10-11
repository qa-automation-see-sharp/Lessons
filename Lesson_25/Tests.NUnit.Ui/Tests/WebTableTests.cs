using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.PageObjects;

namespace Tests.NUnit.Ui.Tests;

[TestFixture]
public class WebTableTests
{
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _page = new WebTablePage();
        _page.OpenInBrowser(BrowserNames.Chrome, "--start-maximized");
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _page.Close();
    }

    private WebTablePage _page;

    [Test]
    public void OpenWebTablePage_TitleIsCorrect()
    {
        _page.NavigateToPage();
        var title = _page.Title?.Text;

        var cellKierra = _page.WebTable?.GetCellFromRows("Kierra");
        cellKierra?.Click();
        var cellKierraText = cellKierra?.Text;

        Assert.Multiple(() =>
        {
            Assert.That(title, Is.EqualTo("Web Tables"));
            Assert.That(cellKierra, Is.Not.Null);
            Assert.That(cellKierraText, Is.EqualTo("Kierra"));
        });
    }
}