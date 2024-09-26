using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using static Tests.Utils.Swd.WebDriverFactory.BrowserNames;

namespace Tests.Utils.Swd.WebDriverFactory;

public static class WebDriverFactory
{
    private static readonly ThreadLocal<IWebDriver?> ThreadLocalDriver = new();

    public static IWebDriver? Driver => ThreadLocalDriver.Value;

    public static void OpenWith(BrowserNames browser, params string[] args)
    {
        switch (browser)
        {
            case Chrome:
                var chromeOptions = new ChromeOptions();
                foreach (var arg in args)
                {
                    chromeOptions.AddArgument(arg);
                }

                ThreadLocalDriver.Value ??= new ChromeDriver(chromeOptions);
                break;
            case Firefox:
                var firefoxOptions = new FirefoxOptions();
                foreach (var arg in args)
                {
                    firefoxOptions.AddArgument(arg);
                }

                ThreadLocalDriver.Value ??= new FirefoxDriver(firefoxOptions);
                break;
            case Edge:
                var edgeOptions = new EdgeOptions();
                foreach (var arg in args)
                {
                    edgeOptions.AddArgument(arg);
                }

                ThreadLocalDriver.Value ??= new EdgeDriver(edgeOptions);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
        }
    }

    public static void CloseBrowser()
    {
        if (ThreadLocalDriver.Value == null) return;

        ThreadLocalDriver.Value?.Quit();
        ThreadLocalDriver.Value?.Dispose();
        ThreadLocalDriver.Value = null;
    }
}