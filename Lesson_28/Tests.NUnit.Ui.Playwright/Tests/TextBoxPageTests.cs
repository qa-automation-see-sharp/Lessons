using Microsoft.Playwright;
using NUnit.Framework.Interfaces;
using static Microsoft.Playwright.Playwright;

namespace Tests.NUnit.Ui.Playwright.Tests;

[TestFixture]
public class TextBoxPageTests
{
    private IBrowser Browser { get; set; }
    private IBrowserContext Context { get; set; }
    private IPage Page { get; set; }

    [OneTimeSetUp]
    public async Task SetUp()
    {
        var playwright = await CreateAsync();
        playwright.Selectors.SetTestIdAttribute("aria-label");

        Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            //Whether to run browser in headless mode.
            //Defaults to true unless the devtools option is true.
            Headless = false,

            //Slows down Playwright operations by the specified amount of milliseconds.
            //Useful so that you can see what is going on.
            SlowMo = 50,

            //Maximum time in milliseconds to wait for the browser instance to start.
            //Defaults to 30000 (30 seconds). Pass 0 to disable timeout
            Timeout = 10000,

            //Additional arguments to pass to the browser instance. The list of Chromium flags can be found here  . 
            // Remarks:
            // Use custom browser args at your own risk, as some of them may break Playwright functionality.
            Args = ["--start-maximized"],
        });

        Context = await Browser.NewContextAsync(new BrowserNewContextOptions
        {
            ViewportSize = ViewportSize.NoViewport, // ViewportSize.NoViewport,
            Locale = "en-US",
            ColorScheme = ColorScheme.NoPreference,
        });

        Page = await Context.NewPageAsync();

        // Set up default timeout for all actions
        Page.SetDefaultTimeout(10000);
        await Page.GotoAsync("https://demoqa.com/text-box");
    }

    [Test]
    public async Task OpenTextBoxPage_TitleIsCorrect()
    {
        var title = await Page.TextContentAsync("h1");

        Assert.That(title, Is.EqualTo("Text Box"));
    }

    [Test]
    public async Task CheckLabelsAreDisplayed()
    {
        var userNameLabel = await Page.Locator("id=userName-label")
            .Filter(new LocatorFilterOptions { HasText = "Full Name" })
            .TextContentAsync();
        var userEmailLabel = await Page.TextContentAsync("#userEmail-label");
        var currentAddressLabel = await Page.TextContentAsync("#currentAddress-label");
        var permanentAddressLabel = await Page.TextContentAsync("#permanentAddress-label");

        Assert.Multiple(() =>
        {
            Assert.That(userNameLabel, Is.EqualTo("Full Name"));
            Assert.That(userEmailLabel, Is.EqualTo("Emaik"));
            Assert.That(currentAddressLabel, Is.EqualTo("Current Address"));
            Assert.That(permanentAddressLabel, Is.EqualTo("Permanent Address"));
        });
    }

    [Test]
    public async Task CompleteTheFormWithData_OutputDisplaysEnteredData()
    {
        //xpath selector
        await Page.Locator("xpath=//*[@id='userName']").FillAsync("Oleh Kutafis");
        //id selector
        await Page.Locator("id=userEmail").FillAsync("kutafin.o.v@gmail.com");
        //css selector
        await Page.FillAsync("#currentAddress", "7270 W Manchester Ave, Los Angeles, CA 90045");
        await Page.FillAsync("#permanentAddress", "13200 Pacific Promenade, Playa Vista, CA 90094");
        await Page.GetByText("Submit").ClickAsync();

        var textToAssert = await Page.Locator("#output").TextContentAsync();


        Assert.Multiple(() =>
        {
            Assert.That(textToAssert, Is.Not.Null);
            Assert.That(textToAssert, Is.Not.Empty);
            Assert.That(textToAssert!.Contains("Oleh Kutafin"));
            Assert.That(textToAssert.Contains("kutafin.o.v@gmail.com"));
            Assert.That(textToAssert.Contains("7270 W Manchester Ave, Los Angeles, CA 90045"));
            Assert.That(textToAssert.Contains("13200 Pacific Promenade, Playa Vista, CA 90094"));
        });
    }

    [TearDown]
    public async Task TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            await TakeScreenShot();
        }
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDown()
    {
        await Page.CloseAsync();
        await Browser.CloseAsync();
    }

    private async Task TakeScreenShot()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var currentDate = DateTime.Now.ToString("dd-MM-yy");
        var currentTime = DateTime.Now.ToString("HH-mm-ss");
        var currentTestFixture = TestContext.CurrentContext.Test.ClassName;
        var screenShotName = $"{TestContext.CurrentContext.Test.Name}.png";
        var path = Path.Combine(currentDirectory, currentDate, currentTime, currentTestFixture, screenShotName);
        await Page.ScreenshotAsync(new PageScreenshotOptions { Path = path });
    }
}