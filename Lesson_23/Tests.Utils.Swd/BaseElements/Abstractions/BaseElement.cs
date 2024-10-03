using System.Drawing;
using OpenQA.Selenium;
using Tests.Utils.Swd.Browser;
using static Tests.Utils.Swd.Helpers.WaitHelper;

namespace Tests.Utils.Swd.BaseElements.Abstractions;

public abstract class BaseElement
{
    public By? Locator { get; init; }

    
    internal IWebElement Element { get; set; }

    public string TagName => FindElement().TagName;
    public string Text => FindElement().Text;
    public bool Enabled => FindElement().Enabled;
    public bool Selected => FindElement().Selected;
    public bool Displayed => FindElement().Displayed;
    public Point Location => FindElement().Location;
    public Size Size => FindElement().Size;

    private IWebElement FindElement()
    {
        return Wait(() => BrowserFactory.Driver.FindElement(Locator),
            element => element is null or { Displayed: false } or { Enabled: false });
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