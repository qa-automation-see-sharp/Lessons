using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using static Microsoft.Playwright.Playwright;

namespace Tests.NUnit.Ui.Playwright;

[TestFixture]
public class Tests : PlaywrightTest
{
    private IPage Page { get; set; }

    [SetUp]
    public async Task Setup()
    {
        var playwright = await CreateAsync();
        playwright.Selectors.SetTestIdAttribute("aria-label");
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            Args = new List<string> { "--start-maximized" }
        });

        IBrowserContext context = await browser.NewContextAsync(new BrowserNewContextOptions
        {
            ViewportSize = ViewportSize.NoViewport,
        });

        Page = await context.NewPageAsync();
        await Page.GotoAsync("https://demoqa.com");
    }

    [Test]
    public async Task Test1()
    {
        await Page.ClickAsync("text=Elements");
        await Page.ClickAsync("text=Check Box");
        await Page.GetByTestId("Toggle").ClickAsync();
        await Page.ClickAsync("text=Desktop");
        await Page.ClickAsync("text=Documents");
        await Page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot.png" });
    }


    //Code Generated with Playwright Test Recorder
    [Test]
    public async Task Test2()
    {
        await Page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Elements$") }).First.ClickAsync();
        await Page.Locator("li").Filter(new() { HasText = "Text Box" }).ClickAsync();
        await Page.GetByPlaceholder("Full Name").ClickAsync();
        await Page.GetByPlaceholder("Full Name").FillAsync("name");
        await Page.GetByPlaceholder("name@example.com").ClickAsync();
        await Page.GetByPlaceholder("name@example.com").FillAsync("email@gmail.com");
        await Page.GetByPlaceholder("Current Address").ClickAsync();
        await Page.GetByPlaceholder("Current Address").FillAsync("some address");
        await Page.Locator("#permanentAddress").ClickAsync();
        await Page.Locator("#permanentAddress").FillAsync("some address");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
        await Page.GetByText("Permananet Address :some").ClickAsync();

        await Expect(Page.Locator("#name")).ToContainTextAsync("name");
        await Expect(Page.Locator("#email")).ToContainTextAsync("email@gmail.com");
        await Expect(Page.Locator("#output")).ToContainTextAsync("some address");
    }

    [TearDown]
    public async Task TearDown()
    {
        await Page.CloseAsync();
    }
}