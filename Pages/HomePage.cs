using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Playwright;

namespace Playwright_Framework.Pages
{
    public class HomePage(IPage page) : BasePage(page)
    {

        public ILocator SearchBox => Page.Locator("#small-searchterms"); // Search input box
        public ILocator SearchButton => Page.GetByRole(AriaRole.Button, new() { Name = "Search" });  //Search button




        // Product list (grid items)
        public ILocator ProductItems => Page.Locator(".product-item");

        public async Task NavigateAsync()
        {
            await Page.GotoAsync("https://demowebshop.tricentis.com/", new()
            {
                WaitUntil = WaitUntilState.DOMContentLoaded
            });

            // Wait for something stable
            await SearchBox.WaitForAsync(new()
            {
                State = WaitForSelectorState.Visible,
                Timeout = 10000
            });
        }

        public async Task SearchAsync(string term)
        {
            await SearchBox.FillAsync(term);
            await SearchButton.ClickAsync();
        }

        public async Task<int> GetProductCountAsync()
        {
            await ProductItems.First.WaitForAsync();
            return await ProductItems.CountAsync();
        }
    }
}
