using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;

namespace Tests.Utils.Swd.Elements;

public class WebElement : IWebElement
{
    private readonly IWebDriver _driver;
    private readonly By _by;
    private IWebElement _element;

    public string TagName { get; }
    public string Text { get; }
    public bool Enabled { get; }
    public bool Selected { get; }
    public bool Displayed { get; }
    public Point Location { get; }
    public Size Size { get; }


    public WebElement(By by, IWebDriver driver)
    {
        _driver = driver;
        _by = by;
    }

    public IWebElement FindElement(By by)
    {
        _element = _driver.FindElement(_by);
        return _element;
    }

    public ReadOnlyCollection<IWebElement> FindElements(By by)
    {
        ReadOnlyCollection<IWebElement> elements;
        try
        {
            elements = _driver.FindElements(by);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return elements;
    }

    public void Clear()
    {
        _driver.FindElement(_by).Clear();
    }

    public void SendKeys(string text)
    {
        _driver.FindElement(_by).SendKeys(text);
    }

    public void Submit()
    {
        _driver.FindElement(_by).Submit();
    }

    public void Click()
    {
        _driver.FindElement(_by).Click();
    }

    public string GetAttribute(string attributeName)
    {
        return _driver.FindElement(_by).GetAttribute(attributeName);
    }

    public string GetDomAttribute(string attributeName)
    {
        return _driver.FindElement(_by).GetAttribute(attributeName);
    }

    public string GetDomProperty(string propertyName)
    {
        return _driver.FindElement(_by).GetAttribute(propertyName);
    }

    public string GetCssValue(string propertyName)
    {
        return _driver.FindElement(_by).GetCssValue(propertyName);
    }

    public ISearchContext GetShadowRoot()
    {
        return _driver.FindElement(_by);
    }
}