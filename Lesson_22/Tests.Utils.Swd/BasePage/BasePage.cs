using Tests.Utils.Swd.WebDriverFactory;
using static Tests.Utils.Swd.Waits.WaitHelper;
using static Tests.Utils.Swd.WebDriverFactory.BrowserFacory;

namespace Tests.Utils.Swd.BasePage;

public abstract class BasePage
{
    public void OpenWith(BrowserNames name, params string[] args)
    {
        WebDriverFactory.BrowserFacory.OpenWith(name, args);
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

    public void Close()
    {
        Driver?.Quit();
    }
}