using OpenQA.Selenium;
using Test.Utils.Swd.BasePage;
using Test.Utils.Swd.WebDriverFactory;
using WebElement = Test.Utils.Swd.BaseElement.WebElement;

namespace Tests.NUnit.Ui.PageObjects;

public class MainPage : BasePage
{
    protected string Url => "https://demoqa.com/";
    protected string Title => Driver!.Title;

    private WebElement Elements()
    {
        return new WebElement(
            By.XPath("//div[@class=\"card mt-4 top-card\"]/div/div/h5[contains(text(),\"Elements\")]"), Driver!);
    }


    public MainPage Open(BrowserNames name, params string[] args)
    {
        OpenWith(name, args);
        NavigateTo(Url);
        return this;
    }

    public ElementsPage ClickOnElements()
    {
        var element = Elements();
            element.Click();
        return new ElementsPage();
    }

    public void Close()
    {
        Driver?.Quit();
    }
}