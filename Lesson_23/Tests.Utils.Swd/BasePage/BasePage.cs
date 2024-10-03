using Tests.Utils.Swd.Browser;
using static Tests.Utils.Swd.Helpers.WaitHelper;
using static Tests.Utils.Swd.Browser.BrowserFactory;

namespace Tests.Utils.Swd.BasePage;

public abstract class BasePage
{
    public void OpenWith(BrowserNames name, params string[] args)
    {
        BrowserFactory.OpenWith(name, args);
    }
    
    protected BasePage()
    {
        Helpers.InitializationHelper.InitializeElements(this);
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