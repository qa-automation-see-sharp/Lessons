using Microsoft.Playwright;
using Test.Utils.Fixtures;
using Test.Utils.PageObjects;
using BrowserType = Test.Utils.Fixtures.BrowserType;

namespace Tests.NUnit.Playwright.Tests;

[TestFixture]
public class TextBoxPageTests
{
    private readonly BrowserSetUp _browserSetUp = new();
    private MainPage Page { get; set; }

    [OneTimeSetUp]
    public async Task OneTimeSetUp()
    {
        Page = await _browserSetUp
            .WithBrowser(BrowserType.Chromium)
            .InHeadlessMode(false)
            .WithChannel("chrome")
            .WithSlowMo(100)
            .WithTimeout(10000)
            .WithArgs("--start-maximized")
            .OpenNewPage<MainPage>();
    }

    [Test]
    public async Task OpenTextBoxPage()
    {
        await Page.OpenAsync();
        await Page.Elements.ClickAsync();
    }
}