using Microsoft.Playwright;
using NUnit.SpecFlow.Playwrigth.Tests.PageObjects;

namespace NUnit.SpecFlow.Playwrigth.Tests.Drivers;

public class PlaywrightDriver
{
    private Browsers Type { get; set; } = Browsers.Chromium;
    private readonly string _date = $"{DateTime.Now:MM-dd-yy}";
    private readonly string _time = $"{DateTime.Now:HH-mm-ss}";
    private readonly BrowserTypeLaunchOptions _browserTypeLaunchOptions = new();

    private readonly BrowserNewContextOptions _browserNewContextOptions = new()
    {
        ViewportSize = ViewportSize.NoViewport,
        Locale = "en-US",
        ColorScheme = ColorScheme.NoPreference
    };

    public IBrowserContext? Context { get; private set; }
    public IPage? Page { get; private set; }

    public IBasePage? CurrentPage { get; private set; }


    public void AddRequestResponseLogger()
    {
        Page!.Request += (_, request) => Console.WriteLine(">> " + request.Method + " " + request.Url);
        Page!.Response += (_, response) => Console.WriteLine("<< " + response.Status + " " + response.Url);
    }

    public async Task StartTracing(string traceName)
    {
        await Context!.Tracing.StartAsync(new()
        {
            Title = traceName,
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });
    }

    public async Task StopTracing(string path)
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var finalPath = Path.Combine(currentDirectory, _date, _time, path);
        await Context!.Tracing.StopAsync(new() { Path = finalPath });
    }

    public async Task Screenshot(string testSuiteName, string screenshotName)
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var finalPath = Path.Combine(currentDirectory, _date, _time, testSuiteName, screenshotName + ".png");
        await Page!.ScreenshotAsync(new() { Path = finalPath });
    }

    public PlaywrightDriver WithBrowser(Browsers type)
    {
        Type = type;
        return this;
    }

    public PlaywrightDriver InHeadlessMode(bool headless)
    {
        _browserTypeLaunchOptions.Headless = headless;
        return this;
    }

    public PlaywrightDriver WithChannel(string channel)
    {
        _browserTypeLaunchOptions.Channel = channel;
        return this;
    }

    public PlaywrightDriver WithSlowMo(int slowMo)
    {
        _browserTypeLaunchOptions.SlowMo = slowMo;
        return this;
    }

    public PlaywrightDriver WithTimeout(int timeout)
    {
        _browserTypeLaunchOptions.Timeout = timeout;
        return this;
    }

    public PlaywrightDriver WithArgs(params string[] args)
    {
        _browserTypeLaunchOptions.Args = args;
        return this;
    }

    public PlaywrightDriver WithLocale(string locale)
    {
        _browserNewContextOptions.Locale = locale;
        return this;
    }

    public PlaywrightDriver WithColorScheme(ColorScheme colorScheme)
    {
        _browserNewContextOptions.ColorScheme = colorScheme;
        return this;
    }

    public PlaywrightDriver WithViewportSize(int width, int height)
    {
        var viewportSize = new ViewportSize
        {
            Width = width,
            Height = height
        };
        _browserNewContextOptions.ViewportSize = viewportSize;
        return this;
    }

    public PlaywrightDriver WithVideoSize(int width, int height)
    {
        _browserNewContextOptions.RecordVideoSize = new()
        {
            Width = width, Height = height
        };
        return this;
    }

    public PlaywrightDriver SaveVideo(string path)
    {
        _browserNewContextOptions.RecordVideoDir = $"{_date}/" + path;
        return this;
    }

    public async Task<T?> InitializeNewPage<T>() where T : class, IBasePage, new()
    {
        var playwright = await Playwright.CreateAsync();
        var browser = Type switch
        {
            Browsers.Chromium => await playwright.Chromium.LaunchAsync(_browserTypeLaunchOptions),
            Browsers.Firefox => await playwright.Firefox.LaunchAsync(_browserTypeLaunchOptions),
            Browsers.WebKit => await playwright.Webkit.LaunchAsync(_browserTypeLaunchOptions),
            _ => throw new ArgumentOutOfRangeException()
        };
        Context = await browser.NewContextAsync(_browserNewContextOptions);
        Page = await Context.NewPageAsync();
        CurrentPage = new T { Page = this.Page };
        return CurrentPage as T;
    }

    public T? GetCurrentPage<T>() where T : class, IBasePage
    {
        return CurrentPage as T;
    }

    public async Task Close()
    {
        await Page!.CloseAsync();
        await Context!.CloseAsync();
    }
}