using OpenQA.Selenium;

namespace Tests.Utils.Swd.BaseElement;

public class CheckBox : WebElement
{
    public CheckBox(By by, IWebDriver driver) : base(by, driver) { }

    public bool Checked => FindElement().Selected;

    public void Check()
    {
        if (!Checked)
        {
            Click();
        }
    }

    public void Uncheck()
    {
        if (Checked)
        {
            Click();
        }
    }
}