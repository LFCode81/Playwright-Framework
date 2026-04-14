using static Microsoft.Playwright.Assertions;
using Playwright_Framework.Fixtures;

namespace Playwright_Framework.Tests.Home
{
    [TestClass]
    public class HomePageTests : TestBase
    {
        [TestMethod]
        public async Task HomePage_Should_Load_Successfully()
        {
            await Pages.Home.NavigateAsync();
            await Page.ScreenshotAsync(new()
            {
                Path = "home-test-debug.png",
                FullPage = true
            });

            await Expect(Pages.Home.SearchBox).ToBeVisibleAsync();

        }
    }
}
