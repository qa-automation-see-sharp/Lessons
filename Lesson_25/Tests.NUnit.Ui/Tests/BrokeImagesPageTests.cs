using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.Helpers;
using Tests.Utils.Swd.PageObjects;

namespace Tests.NUnit.Ui.Tests;

public class BrokeImagesPageTests
{
    private BrokenImagesPage _brokenImagesPage;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _brokenImagesPage = new BrokenImagesPage();
        _brokenImagesPage.OpenInBrowser(BrowserNames.Chrome);
        _brokenImagesPage.NavigateToPage();
    }

    [Test]
    public async Task CheckBrokenImages()
    {
        //JSexecutor
        var checkIfImageOkay = _brokenImagesPage.IsImageBroken(_brokenImagesPage.Image);
        var CheckIfBrokenImageNotOkay = _brokenImagesPage.IsImageBroken(_brokenImagesPage.BrokenImage);

        //HTTP request
        var imageUrl = _brokenImagesPage.Image.GetAttribute("src");
        var brokenImageUrl = _brokenImagesPage.BrokenImage.GetAttribute("src");
        var checkIf2ImageUrlOkay = await _brokenImagesPage.IsImageBroken2(imageUrl);
        var checkIf2BrokenImageUrlNotOkay = await _brokenImagesPage.IsImageBroken2(brokenImageUrl);
        var size = _brokenImagesPage.Image.Size;

        Assert.Multiple(() =>
        {
            Assert.That(checkIfImageOkay, Is.False);
            Assert.That(CheckIfBrokenImageNotOkay, Is.True);
            Assert.That(checkIf2ImageUrlOkay, Is.False);
            Assert.That(checkIf2BrokenImageUrlNotOkay, Is.True);
        });
    }

    [TearDown]
    public void TearDown()
    {
        var testName = TestContext.CurrentContext.Test.MethodName;
        ScreenshotHelper.TakeScreenShoot(testName);
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _brokenImagesPage.Close();
    }
}