using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.BaseWebElements.Elements;
using Tests.Utils.Swd.BaseWebElements.Page.Abstractions;

namespace Tests.Utils.Swd.PageObjects;

public class LinksPage : BasePage
{
    private string Url => "https://demoqa.com/links";

    [FindBy(Id = "simpleLink")] public Element? HomePage { get; set; }

    [FindBy(Id = "dynamicLink")] public Element? DynamicLink { get; set; }

    public LinksPage OpenInBrowser(BrowserNames name, params string[] args)
    {
        OpenWith(name, args);
        return this;
    }

    public LinksPage NavigateToPage()
    {
        NavigateTo(Url);
        return this;
    }

    public MainPage GoToHomePage()
    {
        HomePage?.Click();
        return new MainPage();
    }
}