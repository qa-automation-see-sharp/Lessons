using Microsoft.Playwright;

namespace Test.Utils.PageObjects;

public partial class ButtonsPage : IBasePage
{
    public IPage? Page { get; set; }
    public string Url { get; } = "https://demoqa.com/buttons";
    public string ExpectedTitle { get; } = "Buttons";

    public ILocator Title => Page!.Locator("xpath=//h1[text()='Buttons']");
    public ILocator DoubleClickButton => Page!.Locator("id=doubleClickBtn");
    public ILocator DoubleClickMessage => Page!.Locator("id=doubleClickMessage");
    public ILocator RightClickButton => Page!.Locator("id=rightClickBtn");
    public ILocator RightClickMessage => Page!.Locator("id=rightClickMessage");
    public ILocator ClickMeButton => Page!.Locator("xpath=//button[text()='Click Me']");
    public ILocator ClickMeMessage => Page!.Locator("id=dynamicClickMessage");
    
    public async Task<ButtonsPage> Open()
    {
        await Page!.GotoAsync(Url);
        return this;
    }
    
    public async Task<ButtonsPage> DoubleClick()
    {
        await DoubleClickButton.DblClickAsync();
        return this;
    }
    
    public async Task<ButtonsPage> ClickOnRightClickButton()
    {
        await RightClickButton.ClickAsync(new() { Button = MouseButton.Right });
        return this;
    }
    
    public async Task<ButtonsPage> ClickOnClickMe()
    {
        await ClickMeButton.ClickAsync();
        return this;
    }
}