using OpenQA.Selenium;
using Tests.Utils.Swd.BaseElements.Abstractions;
using Tests.Utils.Swd.Browser;
using static Tests.Utils.Swd.Helpers.WaitHelper;

namespace Tests.Utils.Swd.BaseElements;

public class WebElements : BaseElement
{
    private List<IWebElement> _elements;

    private IEnumerable<IWebElement> FindElements()
    {
        _elements = Wait(
            () => BrowserFactory.Driver.FindElements(Locator).ToList(),
            elements => elements.Count == 0);
        return _elements;
    }

    public IWebElement GetElement(int index)
    {
        return FindElements().ElementAt(index);
    }

    public IWebElement? FirstOrDefault(Func<IWebElement, bool> condition)
    {
        return FindElements().FirstOrDefault(condition);
    }
}