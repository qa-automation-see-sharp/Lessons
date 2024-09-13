using OpenQA.Selenium;

namespace Tests.Utils.Swd.BasePage;

public abstract class BasePage
{
    protected readonly IWebDriver _driver;

    protected BasePage(IWebDriver driver)
    {
        _driver = driver;
    }

    public string GetPageTitle() => _driver.Title;

    public string GetPageUrl() => _driver.Url;

    public void NavigateTo(string url)
    {
        _driver.Navigate().GoToUrl(url);
    }

    public void RefreshPage()
    {
        _driver.Navigate().Refresh();
    }

    public void GoBack()
    {
        _driver.Navigate().Back();
    }

    public void GoForward()
    {
        _driver.Navigate().Forward();
    }
}