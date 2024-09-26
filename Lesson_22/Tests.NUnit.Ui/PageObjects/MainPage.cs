using OpenQA.Selenium;
using Tests.Utils.Swd.BaseElement;
using Tests.Utils.Swd.BasePage;
using static Tests.Utils.Swd.WebDriverFactory.BrowserFacory;

namespace Tests.NUnit.Ui.PageObjects;

public class MainPage : BasePage
{
    public string Url => "https://demoqa.com/";
    public string Title => "DEMOQA";

    private WebElements Elements => new(By.XPath("//div[@class='card-body']"));

    public MainPage Open()
    {
        Driver!.Navigate().GoToUrl(Url);

        return this;
    }
    
    public MainPage GoToCardWithText(string elementName)
    {
        var card = Elements.FirstOrDefault(e=> e.Text.Contains(elementName));
            card?.Click();
        return this;
    }
}