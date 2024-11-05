using Microsoft.Playwright;
using NUnit.SpecFlow.Playwrigth.Tests.Drivers;
using NUnit.SpecFlow.Playwrigth.Tests.PageObjects;
using TechTalk.SpecFlow;

namespace NUnit.SpecFlow.Playwrigth.Tests.Steps;

[Binding]
public class ButtonsPageSteps
{
    private readonly FeatureContext _featureContext;
    private readonly PlaywrightDriver? _driver;
    private ButtonsPage? _buttonsPage;
    
    public ButtonsPageSteps(FeatureContext featureContext)
    {
        _featureContext = featureContext;
        _driver = _featureContext["Driver"] as PlaywrightDriver;
    }
    
    [Given(@"I'm on the Buttons page")]
    public async Task Given_IAmOnButtonsPage()
    {
        _buttonsPage = await _driver!.InitializeNewPage<ButtonsPage>(); 
        await _driver.GetCurrentPage<ButtonsPage>()!.Open();
    }

    [When(@"I double click the button")]
    public async Task When_IDoubleClickTheButton()
    {
        var driver = _driver;
        var page = driver.GetCurrentPage<ButtonsPage>()!;
        await page.DoubleClickButton.DblClickAsync();
    }


    [When(@"I right click the button")]
    public async Task When_IRightClickTheButton()
    {
        var driver = _driver;
        var page = driver.GetCurrentPage<ButtonsPage>()!;
        await page.RightClickButton.ClickAsync(new() { Button = MouseButton.Right });
    }

    [When(@"I click the button")]
    public async Task When_IClickTheButton()
    {
        var driver = _driver;
        var page = driver.GetCurrentPage<ButtonsPage>()!;
        await page.ClickMeButton.ClickAsync();
    }

    [Then(@"I should see text for (usual|right|double) click (.*)")]
    public async Task ThenIShouldSeeTextForDoubleClickYouHaveDoneADoubleClick(string clickType, string text)
    {
        var buttonsPage = _driver!.GetCurrentPage<ButtonsPage>()!;
        var outputText = clickType switch
        {
            "usual" => await buttonsPage.ClickMeMessage.TextContentAsync(),
            "right" => await buttonsPage.RightClickMessage.TextContentAsync(),
            "double" => await buttonsPage.DoubleClickMessage.TextContentAsync(),
            _ => string.Empty
        };
        Assert.That(outputText, Is.EqualTo(text));
    }
}