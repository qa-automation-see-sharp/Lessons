using OpenQA.Selenium;

namespace Tests.Utils.Swd.BaseElement;

public class Button : WebElement
{
    public new string Text => FindElement().Text;
    
    public Button(By by) : base(by) { }
    
    public new void Click()
    {
        FindElement().Click();
    }
}