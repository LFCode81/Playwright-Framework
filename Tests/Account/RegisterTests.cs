using Playwright_Framework.Fixtures;
using static Microsoft.Playwright.Assertions;


namespace Playwright_Framework.Tests.Account;


[TestClass]
public class RegisterTests : TestBase
{
    [TestMethod]
    [TestCategory("Smoke")]
    public async Task User_Can_Open_Register_Page()
    {
        var registerPage = await NavigateToRegisterPageAsync();
        await Expect(registerPage.RegisterButton).ToBeVisibleAsync();
    }
}
