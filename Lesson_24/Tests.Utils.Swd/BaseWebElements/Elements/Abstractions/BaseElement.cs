using System.Drawing;
using OpenQA.Selenium;
using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.Helpers;
using static Tests.Utils.Swd.Helpers.WaitHelper;

namespace Tests.Utils.Swd.BaseWebElements.Elements.Abstractions;

public abstract class BaseElement
{
    protected IWebElement? Element;
    public IWebElement? ParentElement { get; set; }
    public By? Locator { get; init; }

    public string TagName => WaitAndHandleExceptions(() => GetWrappedElement.TagName);
    public string Text => WaitAndHandleExceptions(() => GetWrappedElement.Text);
    public bool Enabled => WaitAndHandleExceptions(() => GetWrappedElement.Enabled);
    public bool Selected => WaitAndHandleExceptions(() => GetWrappedElement.Selected);
    public bool Displayed => WaitAndHandleExceptions(() => GetWrappedElement.Displayed);
    public Point Location => WaitAndHandleExceptions(() => GetWrappedElement.Location);
    public Size Size => WaitAndHandleExceptions(() => GetWrappedElement.Size);

    protected BaseElement()
    {
        InitializationHelper.InitializeElements(this, ParentElement);
    }

    protected IWebElement GetWrappedElement => Element ??= FindElement();

    protected IWebElement FindElement()
    {
        var by = Locator;
        return WaitAndHandleExceptionOrResult(()=> ParentElement is null
                    ? WebDriverFactory.Driver.FindElement(by)
                    : ParentElement.FindElement(by),
            element => element is null or { Displayed: false } or { Enabled: false });
        ;
    }

    public IEnumerable<T> FindElements<T>() where T : BaseElement, new()
    {
        var by = Locator;
        return WaitAndHandleExceptionOrResult(() =>
        {
            var elements = (ParentElement is null
                    ? WebDriverFactory.Driver.FindElements(by)
                    : ParentElement.FindElements(by))
                .Select(e => new T { Element = e, Locator = by }).ToList();
            return elements;
        },
        elements => elements.Count == 0);
    }
    
    public void Clear() => WaitAndHandleExceptions(() => FindElement().Clear());

    public void SendKeys(string text) => WaitAndHandleExceptions(() => FindElement().SendKeys(text));

    public void Submit() => WaitAndHandleExceptions(() => FindElement().Submit());

    public void Click() => WaitAndHandleExceptions(() => FindElement().Click());

    public string GetAttribute(string attributeName)
    {
        return WaitAndHandleExceptions(() => FindElement().GetAttribute(attributeName));
    }

    public string GetDomAttribute(string attributeName)
    {
        return WaitAndHandleExceptions(() => FindElement().GetAttribute(attributeName));
    }

    public string GetDomProperty(string propertyName)
    {
        return WaitAndHandleExceptions(() => FindElement().GetAttribute(propertyName));
    }

    public string GetCssValue(string propertyName)
    {
        return WaitAndHandleExceptions(() => FindElement().GetCssValue(propertyName));
    }

    public ISearchContext GetShadowRoot()
    {
        return WaitAndHandleExceptions(() => FindElement().GetShadowRoot());
    }
}