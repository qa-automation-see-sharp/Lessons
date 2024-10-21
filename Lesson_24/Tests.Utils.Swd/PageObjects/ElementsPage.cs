using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Elements;
using Tests.Utils.Swd.BaseWebElements.Page.Abstractions;


namespace Tests.Utils.Swd.PageObjects;

public class ElementsPage : BasePage
{
    [FindBy(XPath = "//span[contains(text(),\"Text Box\")]")]
    private Button? TextBox { get; set; }


    public TextBoxPage OpenTextBox()
    {
        TextBox?.Click();
        return new TextBoxPage();
    }
}