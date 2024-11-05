using NUnit.Framework.Interfaces;
using NUnit.SpecFlow.Playwrigth.Tests.Drivers;
using TechTalk.SpecFlow;

namespace NUnit.SpecFlow.Playwrigth.Tests.Hooks;

[Binding]
public class Hooks
{
    private static readonly PlaywrightDriver Driver = new();

    [BeforeFeature]
    public static void BeforeFeature(FeatureContext context)
    {
        Driver.WithTimeout(10000);
        var tags = context.FeatureInfo.Tags;
        var args = GetBrowserArgs(tags);
        if (args is { Length: > 0 })
        {
            Driver.WithArgs(args);
        }

        context["Driver"] = Driver;
    }
    
    [BeforeFeature("@chrome")]
    public static void WithChrome()
    {
        Driver
            .WithBrowser(Browsers.Chromium)
            .WithChannel(Channels.Chrome);
    }

    [BeforeFeature("@firefox")]
    public static void WithFireFox()
    {
        Driver.WithBrowser(Browsers.Firefox);
    }

    [BeforeFeature("@notHeadless")]
    public static void IsHeadless()
    {
        Driver.InHeadlessMode(false);
    }

    [BeforeFeature("@slowMo")]
    public static void WithSlowMo()
    {
        Driver.WithSlowMo(100);
    }

    [BeforeFeature("@withVideo")]
    public static void SaveVideo()
    {
        Driver
            .WithVideoSize(1900, 1080)
            .SaveVideo("videos/");
    }

    [AfterScenario]
    public static async Task AfterScenario()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            await Driver.Screenshot(
                TestContext.CurrentContext.Test.ClassName!,
                TestContext.CurrentContext.Test.Name);
        }
    }

    [AfterFeature]
    public static async Task AfterFeature()
    {
        await Driver.Close();
    }

    private static string[]? GetBrowserArgs(string[] tags)
    {
        string[]? args = null;
        foreach (var tag in tags)
        {
            var match = tag.StartsWith("args(");

            if (match)
            {
                args = tag
                    .Trim("args(".ToCharArray()).Trim(')')
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(arg => arg.Trim('"'))
                    .ToArray();
            }
        }

        return args;
    }
}