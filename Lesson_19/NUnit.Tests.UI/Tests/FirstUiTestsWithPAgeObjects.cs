using NUnit.Tests.UI.PageObjects;
using OpenQA.Selenium;
using Tests.Utils.Swd.Browser;

namespace NUnit.Tests.UI.Tests;

[TestFixture]
public class FirstUiTestsWithPAgeObjects
{
    private IWebDriver? _driver;
    
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _driver =  WebDriverFactory.CreateWebDriver(BrowserNames.Chrome);
    }
    
    [Test]
    public void FirstUiTest()
    {
        var mainPage = new MainPage(_driver);
        var mainPageTitle = mainPage.OpenMainPage().GetPageTitle();
        
        var elementsPage = mainPage.ClickOnElements();
            elementsPage.EnterName("Oleh Kutafin");
            
        var accordionIsPResent = elementsPage.CheckAccordion();
           
        Assert.Multiple(() =>
        {
            Assert.That(mainPageTitle, Is.EqualTo("DEMOQA"));   
            Assert.That(accordionIsPResent, Is.True);
        });

    }
    
    [Test]
    public async Task SecondUiTest()
    {
        await Task.Delay(50);
        var mainPage = new MainPage(_driver);
        var mainPageTitle = mainPage.OpenMainPage().GetPageTitle();
        
        var elementsPage = mainPage.ClickOnElements();
        elementsPage.EnterName("Oleh Kutafin");
            
        var accordionIsPResent = elementsPage.CheckAccordion();
           
        Assert.Multiple(() =>
        {
            Assert.That(mainPageTitle, Is.EqualTo("DEMOQA"));   
            Assert.That(accordionIsPResent, Is.True);
        });

    }
    
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _driver?.Quit();
    }
}