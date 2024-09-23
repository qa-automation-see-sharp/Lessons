using OpenQA.Selenium;
using Test.Utils.Swd.WebDriverFactory;
using static Test.Utils.Swd.Waits.WaitHelper;
using static Test.Utils.Swd.WebDriverFactory.WebDriverFactory;

namespace Test.Utils.Swd.BasePage;

public abstract class BasePage
{
    protected IWebDriver? Driver;

    protected void OpenWith(BrowserNames name, params string[] args)
    {
        Driver = CreateWebDriver(name, args);
    }

    public string GetPageTitle() => Driver!.Title;

    public string GetPageUrl() => Driver!.Url;

    public void NavigateTo(string url)
    {
        Wait(() => Driver?.Navigate().GoToUrl(url));
    }

    public void RefreshPage()
    {
        Wait(() => Driver?.Navigate().Refresh());
    }

    public void GoBack()
    {
        Wait(() => Driver?.Navigate().Back());
    }

    public void GoForward()
    {
        Wait(() => Driver?.Navigate().Forward());
    }
}