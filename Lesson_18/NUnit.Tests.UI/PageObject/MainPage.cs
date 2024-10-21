using OpenQA.Selenium;

namespace NUnit.Tests.UI.PageObject;

public class MainPage
{
    private readonly IWebDriver _driver;
    private const string Url = "https://www.google.com";

    private static By? SearchInput => By.XPath("//textarea[@class='gLFyf']");

    private static By? FirstElementInSearch =>
        By.XPath("//span/a[@href='https://www.selenium.dev/']/h3[contains(text(),'Selenium')]");

    public MainPage(IWebDriver driver)
    {
        _driver = driver;
        _driver.Navigate().GoToUrl(Url);
    }

    public MainPage Search(string text)
    {
        var searchInput = _driver.FindElement(SearchInput);
        searchInput.SendKeys(text);
        searchInput.SendKeys(Keys.Enter);

        return this;
    }

    public IWebElement GetFirstElementInSearch()
    {
        return _driver.FindElement(FirstElementInSearch);
    }

    public void BrowserQuit()
    {
        _driver.Quit();
    }
}