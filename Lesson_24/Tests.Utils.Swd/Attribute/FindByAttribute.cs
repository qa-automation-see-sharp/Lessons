using OpenQA.Selenium;

namespace Tests.Utils.Swd.Attribute;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class)]
public class FindByAttribute : System.Attribute
{
    public string Id { get; set; }
    public string CssSelector { get; set; }
    public string XPath { get; set; }
    public string Name { get; set; }
    public string ClassName { get; set; }
    public string TagName { get; set; }
    public string LinkText { get; set; }
    public string PartialLinkText { get; set; }

    public By GetLocator()
    {
        if (!string.IsNullOrEmpty(Id)) return By.Id(Id);
        if (!string.IsNullOrEmpty(CssSelector)) return By.CssSelector(CssSelector);
        if (!string.IsNullOrEmpty(XPath)) return By.XPath(XPath);
        if (!string.IsNullOrEmpty(Name)) return By.Name(Name);
        if (!string.IsNullOrEmpty(ClassName)) return By.ClassName(ClassName);
        if (!string.IsNullOrEmpty(TagName)) return By.TagName(TagName);
        if (!string.IsNullOrEmpty(LinkText)) return By.LinkText(LinkText);
        if (!string.IsNullOrEmpty(PartialLinkText)) return By.PartialLinkText(PartialLinkText);

        throw new ArgumentException("No valid locator provided in the FindBy attribute.");
    }
}