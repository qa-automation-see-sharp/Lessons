using System.Drawing;
using OpenQA.Selenium;
using Tests.Utils.Swd.WebDriverFactory;
using static Tests.Utils.Swd.Waits.WaitHelper;

namespace Tests.Utils.Swd.BaseElement;

public class WebElement
{
    private readonly IWebDriver _driver;
    private readonly By _by;
    private IWebElement _element;

    public string TagName => FindElement().TagName;
    public string Text => FindElement().Text;
    public bool Enabled => FindElement().Enabled;
    public bool Selected => FindElement().Selected;
    public bool Displayed => FindElement().Displayed;
    public Point Location => FindElement().Location;
    public Size Size => FindElement().Size;


    public WebElement(By by)
    {
        _driver = BrowserFacory.Driver;
        _by = by;
    }

    protected IWebElement FindElement()
    {
        _element = Wait(
            () => _driver.FindElement(_by),
            element => element is null or { Displayed: false } or { Enabled: false });
        return _element;
    }

    public void Clear()
    {
        FindElement().Clear();
    }

    public void SendKeys(string text)
    {
        FindElement().SendKeys(text);
    }

    public void Submit()
    {
        FindElement().Submit();
    }

    public void Click()
    {
        FindElement().Click();
    }

    public string GetAttribute(string attributeName)
    {
        return FindElement().GetAttribute(attributeName);
    }

    public string GetDomAttribute(string attributeName)
    {
        return FindElement().GetAttribute(attributeName);
    }

    public string GetDomProperty(string propertyName)
    {
        return FindElement().GetAttribute(propertyName);
    }

    public string GetCssValue(string propertyName)
    {
        return FindElement().GetCssValue(propertyName);
    }

    public ISearchContext GetShadowRoot()
    {
        return FindElement().GetShadowRoot();
    }
}