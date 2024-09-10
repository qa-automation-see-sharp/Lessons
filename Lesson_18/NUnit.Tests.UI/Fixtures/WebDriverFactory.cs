using NUnit.Tests.UI.PageObject;
using OpenQA.Selenium.Chrome;

namespace NUnit.Tests.UI.Fixtures;

public static class WebDriverFactory
{
    public static MainPage OpenGoogle()
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--start-maximized");

        var driver = new ChromeDriver(chromeOptions);
        return new MainPage(driver);
    }
}