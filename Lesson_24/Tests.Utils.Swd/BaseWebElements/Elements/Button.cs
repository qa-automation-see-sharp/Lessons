using OpenQA.Selenium.Interactions;
using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.BaseWebElements.Elements.Abstractions;

namespace Tests.Utils.Swd.BaseWebElements.Elements;

public class Button : BaseElement
{
    public void RightClick()
    {
        var action = new Actions(WebDriverFactory.Driver);
        var elementToClick = FindElement();
            action.ContextClick(elementToClick).Build().Perform();
    }

    public void DoubleClick()
    {
        var action = new Actions(WebDriverFactory.Driver);
        var elementToClick = FindElement();
            action.DoubleClick(elementToClick).Build().Perform();
    }
}