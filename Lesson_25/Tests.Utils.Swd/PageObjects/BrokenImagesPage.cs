using OpenQA.Selenium;
using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.BaseWebElements.Elements;
using Tests.Utils.Swd.BaseWebElements.Elements.Abstractions;
using Tests.Utils.Swd.BaseWebElements.Page.Abstractions;

namespace Tests.Utils.Swd.PageObjects;

public class BrokenImagesPage : BasePage
{
    private readonly string PageUrl = "https://demoqa.com/broken";

    [FindBy(XPath = "//img[@src='/images/Toolsqa.jpg']")]
    public Element Image { get; set; }

    [FindBy(XPath = "//img[@src='/images/Toolsqa_1.jpg']")]
    public Element BrokenImage { get; set; }

    public BrokenImagesPage OpenInBrowser(BrowserNames name, params string[] args)
    {
        OpenWith(name, args);
        return this;
    }

    public BrokenImagesPage NavigateToPage()
    {
        NavigateTo(PageUrl);
        return this;
    }

    public bool IsImageBroken(BaseElement element)
    {
        var jsExecutor = (IJavaScriptExecutor)WebDriverFactory.Driver;
        var isBroken = (bool)jsExecutor.ExecuteScript(
            "return arguments[0].naturalWidth == 0 && arguments[0].naturalHeight == 0;", element.GetWrappedElement);
        return isBroken;
    }

    public async Task<bool> IsImageBroken2(string imgUrl)
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(imgUrl);
        var statusCode = response.StatusCode;
        return response.IsSuccessStatusCode;
    }
}