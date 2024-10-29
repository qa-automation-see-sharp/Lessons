using Microsoft.Playwright;
using NUnit.Framework.Interfaces;
using Test.Utils.Fixtures;
using Test.Utils.PageObjects;
using BrowserType = Test.Utils.Fixtures.BrowserType;

namespace Tests.NUnit.Playwright.Tests;

[TestFixture]
public class ButtonsPageTests
{
    private readonly BrowserSetUp _browserSetUp = new();
    private ButtonsPage? Page { get; set; }

    [OneTimeSetUp]
    public async Task OneTimeSetUp()
    {
        Page = await _browserSetUp
            .WithBrowser(BrowserType.Chromium)
            .WithChannel("chrome")
            .InHeadlessMode(false)
            .WithSlowMo(100)
            .WithTimeout(10000)
            .WithVideoSize(1900, 1080)
            .SaveVideo("videos/")
            .WithArgs("--start-maximized")
            .OpenNewPage<ButtonsPage>();
        _browserSetUp.AddRequestResponseLogger();
        await Page!.Open();
    }

    [SetUp]
    public async Task SetUp()
    {
        var traceName = TestContext.CurrentContext.Test.ClassName + "/" + TestContext.CurrentContext.Test.Name;
        await _browserSetUp.StartTracing(traceName);
    }

    [Test]
    public async Task OpenButtonsPage()
    {
        var title = await Page!.Title.TextContentAsync();
        
        Assert.That(title, Is.EqualTo(Page!.ExpectedTitle));
    }

    [Test]
    public async Task DoubleClickButtonTest()
    {
        var isVisible = await Page!.DoubleClickButton.IsVisibleAsync();
        var isButtonEnabled = await Page!.DoubleClickButton.IsEnabledAsync();

        await Page.DoubleClickButton.DblClickAsync();

        var textOutput = await Page.DoubleClickMessage.TextContentAsync();

        Assert.Multiple(() =>
        {
            Assert.That(isVisible, Is.True);
            Assert.That(isButtonEnabled, Is.True);
            Assert.That(textOutput, Is.EqualTo("You double clicked the button!"));
        });
    }

    [Test]
    public async Task RightClickButtonTest()
    {
        var isVisible = await Page!.RightClickButton.IsVisibleAsync();
        var isButtonEnabled = await Page!.RightClickButton.IsEnabledAsync();

        await Page.RightClickButton.ClickAsync(new() { Button = MouseButton.Right });

        var textOutput = await Page.RightClickMessage.TextContentAsync();

        Assert.Multiple(() =>
        {
            Assert.That(isVisible, Is.True);
            Assert.That(isButtonEnabled, Is.True);
            Assert.That(textOutput, Is.EqualTo("You right clicked the button!"));
        });
    }

    [Test]
    public async Task ClickMeButtonTest()
    {
        var isVisible = await Page!.ClickMeButton.IsVisibleAsync();
        var isButtonEnabled = await Page!.ClickMeButton.IsEnabledAsync();

        await Page.ClickMeButton.ClickAsync();

        var textOutput = await Page.ClickMeMessage.TextContentAsync();

        Assert.Multiple(() =>
        {
            Assert.That(isVisible, Is.True);
            Assert.That(isButtonEnabled, Is.True);
            Assert.That(textOutput, Is.EqualTo("You have done a dynamic click"));
        });
    }

    [TearDown]
    public async Task TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            await _browserSetUp.Screenshot(
                TestContext.CurrentContext.Test.ClassName,
                TestContext.CurrentContext.Test.Name);
        }

        var tracePAth = Path.Combine(
            "playwright-traces",
            $"{TestContext.CurrentContext.Test.ClassName}",
            $"{TestContext.CurrentContext.Test.Name}.zip");
        await _browserSetUp.StopTracing(tracePAth);
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDown()
    {
        await _browserSetUp.Page!.CloseAsync();
        await _browserSetUp.Context!.CloseAsync();
    }
}