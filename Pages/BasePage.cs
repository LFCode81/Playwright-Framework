using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Playwright;
using Playwright_Framework.Components;

namespace Playwright_Framework.Pages
{
    public abstract class BasePage(IPage page)
    {

        protected readonly IPage Page = page;

        //Common components
        public SearchComponent Search => new(Page);
        public MenuBarComponent MenuBar => new(Page);

        public ProductToolbarComponent ProductToolbar => new(Page);

        public HeaderLinksComponent HeaderLinks => new(Page);

        public async Task WaitForPageAsync()
        {
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);  // Change this....
        }

    }
}
