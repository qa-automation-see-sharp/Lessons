using Microsoft.Playwright;

namespace NUnit.SpecFlow.Playwrigth.Tests.PageObjects;

public interface IBasePage
{
    public IPage? Page { get; set; }
    public string Url { get; }
    public string ExpectedTitle { get; }
}