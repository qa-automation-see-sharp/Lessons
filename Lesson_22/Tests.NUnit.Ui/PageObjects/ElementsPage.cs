using OpenQA.Selenium;
using Tests.Utils.Swd.BaseElement;
using Tests.Utils.Swd.BasePage;

namespace Tests.NUnit.Ui.PageObjects;

public class ElementsPage : BasePage
{
    private Button TextBox => new(By.XPath("//span[contains(text(),\"Text Box\")]"));

    public void OpenTextBox()
    {
        TextBox.Click();
    }
}