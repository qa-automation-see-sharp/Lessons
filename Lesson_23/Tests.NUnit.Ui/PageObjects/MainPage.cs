using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseElements;
using Tests.Utils.Swd.BasePage;
using static Tests.Utils.Swd.Browser.BrowserFactory;

namespace Tests.NUnit.Ui.PageObjects;

public class MainPage : BasePage
{
    public string Url => "https://demoqa.com/";
    public string Title => "DEMOQA";

    [FindBy(XPath = "//div[@class='card-body']")]
    private WebElements Elements { get; set; }

    public MainPage Open()
    {
        Driver!.Navigate().GoToUrl(Url);

        return this;
    }

    public MainPage GoToCardWithText(string elementName)
    {
        var card = Elements.FirstOrDefault(e => e.Text.Contains(elementName));
        card?.Click();
        return this;
    }
}