using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.BaseWebElements.Elements;
using Tests.Utils.Swd.BaseWebElements.Page.Abstractions;

namespace Tests.Utils.Swd.PageObjects;

public class MainPage : BasePage
{
    private string Url => "https://demoqa.com/";
    public string Title => "DEMOQA";

    [FindBy(XPath = "//div[@class='card-body']")]
    public Elements<Element> Cards { get; set; }

    public MainPage OpenInBrowser(BrowserNames name, params string[] args)
    {
        OpenWith(name, args);
        return this;
    }

    public MainPage NavigateToPage()
    {
        NavigateTo(Url);
        return this;
    }

    public ElementsPage ClickOnCardWithName(string cardName)
    {
        Cards.FirstOrDefault(e => e.Text.Contains(cardName))?.Click();
        return new ElementsPage();
    }
}