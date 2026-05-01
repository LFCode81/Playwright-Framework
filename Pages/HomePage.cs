
using Microsoft.Playwright;


namespace Playwright_Framework.Pages
{
    public class HomePage(IPage page) : BasePage(page)
    {

        public ILocator WelcomeHeading => Page.GetByRole(AriaRole.Heading, new() { Name = "Welcome to our store" });  
    
        public async Task NavigateAsync()
        {
            await Page.GotoAsync("https://demowebshop.tricentis.com/", new()
            {
                WaitUntil = WaitUntilState.DOMContentLoaded
            });

            // Wait for something stable
            await WelcomeHeading.WaitForAsync(new()
            {
               State = WaitForSelectorState.Visible,
               Timeout = 10000
            });
        }
    }
}
