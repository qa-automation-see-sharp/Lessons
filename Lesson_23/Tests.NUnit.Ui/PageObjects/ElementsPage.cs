using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseElements;
using Tests.Utils.Swd.BasePage;


namespace Tests.NUnit.Ui.PageObjects;

public class ElementsPage : BasePage
{
    [FindBy(XPath = "//span[contains(text(),\"Text Box\")]")]
    public Button TextBox { get; set; }

    public void OpenTextBox()
    {
        TextBox.Click();
    }
}