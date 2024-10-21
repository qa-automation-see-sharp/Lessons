using OpenQA.Selenium;
using Tests.Utils.Swd.BasePage;

namespace NUnit.Tests.UI.PageObjects;

public class MainPage : BasePage
{
    protected string Url => "https://demoqa.com/";
    protected string Title => _driver.Title;

    private By Elemnts => By.XPath("//div[@class=\"card mt-4 top-card\"]/div/div/h5[contains(text(),\"Elements\")]");

    public MainPage(IWebDriver driver) : base(driver)
    {
    }

    public MainPage OpenMainPage()
    {
        NavigateTo(Url);
        return this;
    }

    public ElementsPage ClickOnElements()
    {
        _driver.FindElement(Elemnts).Click();
        return new ElementsPage(_driver);
    }
}