using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.BaseWebElements.Elements;
using Tests.Utils.Swd.BaseWebElements.Page.Abstractions;

namespace Tests.Utils.Swd.PageObjects;

public class TextBoxPage : BasePage
{
    public string Url => "https://demoqa.com/text-box";

    [FindBy(XPath = "//h1[contains(text(),\"Text Box\")]")]
    public Element? Title { get; set; }

    [FindBy(Id = "userName-label")]
    public Element? UserNameLabel { get; set; }
    [FindBy(Id = "userName")]
    public Input? UserName { get; set; }
    [FindBy(Id = "userEmail-label")]
    public Element? UserEmailLabel { get; set; }
    [FindBy(Id = "userEmail")]
    public Input? UserEmail { get; set; }
    [FindBy(Id = "currentAddress-label")]
    public Element? CurrentAddressLabel { get; set; }
    [FindBy(Id = "currentAddress")]
    public Input? CurrentAddress { get; set; }
    [FindBy(Id = "permanentAddress-label")]
    public Element? PermanentAddressLabel { get; set; }
    [FindBy(Id = "permanentAddress")]
    public Input? PermanentAddress { get; set; }
    [FindBy(XPath = "//*[@id='submit']")]
    public Button? Submit { get; set; }
    [FindBy(Id = "output")]
    public Element? Output { get; set; }

    public TextBoxPage OpenInBrowser(BrowserNames name, params string[] args)
    {
        OpenWith(name, args);
        return this;
    }
    
    public TextBoxPage NavigateToPage()
    {
        NavigateTo(Url);
        return this;
    }

    public TextBoxPage EnterFullName(string fullName)
    {
        UserName?.SendKeys(fullName);
        return this;
    }

    public TextBoxPage EnterEmail(string email)
    {
        UserEmail?.SendKeys(email);
        return this;
    }

    public TextBoxPage EnterCurrentAddress(string currentAddress)
    {
        CurrentAddress?.SendKeys(currentAddress);
        return this;
    }

    public TextBoxPage EnterPermanentAddress(string permanentAddress)
    {
        PermanentAddress?.SendKeys(permanentAddress);
        return this;
    }
}