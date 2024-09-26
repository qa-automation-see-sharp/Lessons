using OpenQA.Selenium;
using static Tests.Utils.Swd.Waits.WaitHelper;

namespace Tests.Utils.Swd.BaseElement;

public class WebElements
{
    private readonly IWebDriver _driver;
    private readonly By _by;
    private List<IWebElement> _elements;

    public WebElements(By by)
    {
        _by = by;
        _driver = WebDriverFactory.WebDriverFactory.Driver;
    }

    private IEnumerable<IWebElement> FindElements()
    {
        _elements = Wait(
            () => _driver.FindElements(_by).ToList(),
            elements => elements.Count == 0);
        return _elements;
    }

    public IWebElement GetElement(int index)
    {
        return FindElements().ElementAt(index);
    }
    
    public void SomeAction(int index, string text)
    {
       var element = GetElement(index);

       Wait(() => element.SendKeys(text));
    }

    public IWebElement? FirstOrDefault(Func<IWebElement, bool> condition)
    {
        return FindElements().FirstOrDefault(condition);
    }
}