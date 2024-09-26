using OpenQA.Selenium;

namespace Tests.Utils.Swd.BaseElement;

public class Input : WebElement
{
    public new string Text => FindElement().Text; 
    
    public Input(By by, IWebDriver driver) : base(by, driver)
    {
    }

    public new void Clear()
    {
        FindElement().Clear();
    }

    public new void SendKeys(string text)
    {
        FindElement().SendKeys(text);
    }
}