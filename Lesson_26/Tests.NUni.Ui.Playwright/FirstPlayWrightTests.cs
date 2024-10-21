using Microsoft.Playwright;
using static Microsoft.Playwright.Playwright;

namespace Tests.NUni.Ui.Playwright;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        using var playwright = await CreateAsync();
        playwright.Selectors.SetTestIdAttribute("aria-label");
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });

        var page = await browser.NewPageAsync();


        await page.GotoAsync("https://demoqa.com");
        await page.ClickAsync("text=Elements");
        await page.ClickAsync("text=Check Box");
        await page.GetByTestId("Toggle").ClickAsync();
        await page.ClickAsync("text=Desktop");
        await page.ClickAsync("text=Documents");
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot.png" });
    }
}