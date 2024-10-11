using Tests.Utils.Swd.BaseWebElements.Browser;
using static Tests.Utils.Swd.BaseWebElements.Browser.WebDriverFactory;
using static Tests.Utils.Swd.Helpers.InitializationHelper;
using static Tests.Utils.Swd.Helpers.WaitHelper;


namespace Tests.Utils.Swd.BaseWebElements.Page.Abstractions;

public class BasePage
{
    protected BasePage()
    {
        InitializeElements(this);
    }

    protected void OpenWith(BrowserNames name, params string[] args)
    {
        WebDriverFactory.OpenWith(name, args);
    }

    public string GetPageTitle()
    {
        return Driver!.Title;
    }

    public string GetPageUrl()
    {
        return Driver!.Url;
    }

    protected void NavigateTo(string url)
    {
        Wait(() => Driver.Navigate().GoToUrl(url));
    }

    public void RefreshPage()
    {
        Wait(() => Driver.Navigate().Refresh());
    }

    public void GoBack()
    {
        Wait(() => Driver.Navigate().Back());
    }

    public void GoForward()
    {
        Wait(() => Driver.Navigate().Forward());
    }

    public string GetCurrentWindow()
    {
        return Driver.CurrentWindowHandle;
    }

    public void SwitchToAnotherWindow(string currentWindow)
    {
        var windows = Driver.WindowHandles;
        var windowToSwitch = windows.FirstOrDefault(w => w != currentWindow);

        Driver
            .SwitchTo().Window(windowToSwitch)
            .SwitchTo().Window(currentWindow);
    }


    public void SwitchToTabByUrl(string url)
    {
        var windows = Driver.WindowHandles;

        foreach (var window in windows)
        {
            Driver.SwitchTo().Window(window);
            var currentUrl = Driver.Url;
            if (currentUrl == url) break;
        }
    }

    public void Close()
    {
        CloseBrowser();
    }
}