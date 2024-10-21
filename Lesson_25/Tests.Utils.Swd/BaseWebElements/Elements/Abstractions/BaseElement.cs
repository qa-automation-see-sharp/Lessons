using System.Drawing;
using OpenQA.Selenium;
using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.Helpers;
using static Tests.Utils.Swd.Helpers.WaitHelper;

namespace Tests.Utils.Swd.BaseWebElements.Elements.Abstractions;

public abstract class BaseElement
{
    protected IWebElement? Element;

    protected BaseElement()
    {
        InitializationHelper.InitializeElements(this, ParentElement);
    }

    public IWebElement? ParentElement { get; set; }
    public By? Locator { get; init; }

    public string TagName => Wait(() => GetWrappedElement.TagName);
    public string Text => Wait(() => GetWrappedElement.Text);
    public bool Enabled => Wait(() => GetWrappedElement.Enabled);
    public bool Selected => Wait(() => GetWrappedElement.Selected);
    public bool Displayed => Wait(() => GetWrappedElement.Displayed);
    public Point Location => Wait(() => GetWrappedElement.Location);
    public Size Size => Wait(() => GetWrappedElement.Size);

    public IWebElement GetWrappedElement => Element ??= FindElement();

    protected IWebElement FindElement()
    {
        var by = Locator;
        return WaitAndReturn(() => ParentElement is null
                ? WebDriverFactory.Driver.FindElement(by)
                : ParentElement.FindElement(by),
            element => element is null or { Displayed: false } or { Enabled: false });
    }

    public IEnumerable<T> FindElements<T>() where T : BaseElement, new()
    {
        var by = Locator;
        return WaitAndReturn(() =>
            {
                var elements = (ParentElement is null
                        ? WebDriverFactory.Driver.FindElements(by)
                        : ParentElement.FindElements(by))
                    .Select(e => new T { Element = e, Locator = by }).ToList();
                return elements;
            },
            elements => elements.Count == 0);
    }

    public void Clear()
    {
        Wait(() => FindElement().Clear());
    }

    public void SendKeys(string text)
    {
        Wait(() => FindElement().SendKeys(text));
    }

    public void Submit()
    {
        Wait(() => FindElement().Submit());
    }

    public void Click()
    {
        Wait(() => FindElement().Click());
    }

    public string GetAttribute(string attributeName)
    {
        return Wait(() => FindElement().GetAttribute(attributeName));
    }

    public string GetDomAttribute(string attributeName)
    {
        return Wait(() => FindElement().GetAttribute(attributeName));
    }

    public string GetDomProperty(string propertyName)
    {
        return Wait(() => FindElement().GetAttribute(propertyName));
    }

    public string GetCssValue(string propertyName)
    {
        return Wait(() => FindElement().GetCssValue(propertyName));
    }

    public ISearchContext GetShadowRoot()
    {
        return Wait(() => FindElement().GetShadowRoot());
    }
}