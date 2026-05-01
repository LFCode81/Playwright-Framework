using Playwright_Framework.Fixtures;
using static Microsoft.Playwright.Assertions;

namespace Playwright_Framework.Tests.Account;

[TestClass]
public class LoginTests : TestBase
{
    [TestMethod]
    [TestCategory("Smoke")]
    public async Task User_Can_Open_Login_Page()
    {
        var loginPage = await NavigateToLoginPageAsync();
        await Expect(loginPage.LoginTitle).ToBeVisibleAsync();
    }
}
