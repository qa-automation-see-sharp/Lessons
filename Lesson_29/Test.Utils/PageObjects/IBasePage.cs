using Microsoft.Playwright;

namespace Test.Utils.PageObjects;

public interface IBasePage
{
    public IPage? Page { get; set; }
    public string Url { get; }
    public string ExpectedTitle { get; }
}