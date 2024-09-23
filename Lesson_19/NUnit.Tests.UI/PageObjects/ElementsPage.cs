using OpenQA.Selenium;

namespace NUnit.Tests.UI.PageObjects;

public class ElementsPage : MainPage
{
    protected string Url => "https://demoqa.com/text-box";
    protected string Title => _driver.Title;

    private By Accordion => By.XPath("//div[@class=\"accordion\"]");
    private By TextBox => By.XPath("//span[contains(text(),\"Text Box\")]");
    private By TextBoxTitle => By.XPath("//h1[contains(text(),\"Text Box\")]]");
    private By FullName => By.Id("userName");

    public ElementsPage(IWebDriver driver) : base(driver)
    {
    }

    public bool CheckAccordion()
    {
        return _driver.FindElement(Accordion).Displayed;
    }

    public ElementsPage EnterName(string fullName)
    {
        _driver.FindElement(TextBox).Click();
        _driver.FindElement(FullName).SendKeys(fullName);

        return this;
    }
}