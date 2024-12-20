using OpenQA.Selenium;
using Tests.Utils.Swd.BaseWebElements.Elements.Abstractions;

namespace Tests.Utils.Swd.BaseWebElements.Elements;

public class Elements<T> : BaseElement
    where T : BaseElement, new()
{
    public Elements(By locator, IWebElement parent)
    {
        Locator = locator;
        ParentElement = parent;
    }

    public int Count => FindElements<T>().Count();

    public IEnumerable<T> GetElements()
    {
        return FindElements<T>();
    }

    public T GetElement(int index)
    {
        return FindElements<T>().ElementAt(index);
    }

    public T? FirstOrDefault(Func<T, bool> condition)
    {
        return FindElements<T>().FirstOrDefault(condition);
    }
}