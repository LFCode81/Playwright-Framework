using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Playwright;

namespace Playwright_Framework.Pages
{
    public abstract class BasePage(IPage page)
    {

        protected readonly IPage Page = page;

        public async Task WaitForPageAsync()
        {
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }
    }
}
