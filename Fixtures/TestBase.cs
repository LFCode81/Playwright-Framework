using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Playwright;
using Playwright_Framework.Factories;

namespace Playwright_Framework.Fixtures
{
    public abstract class TestBase
    {
        protected IPlaywright Playwright = null!;
        protected IBrowser Browser = null!;
        protected IBrowserContext Context = null!;
        protected IPage Page = null!;
        protected PageObjectFactory Pages => new(Page);



        [TestInitialize]
        public async Task Setup()
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            });

            Context = await Browser.NewContextAsync();

            Page = await Context.NewPageAsync();
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            if (Context != null)
                await Context.CloseAsync();

            if (Browser != null)
                await Browser.CloseAsync();

            Playwright?.Dispose();
        }
    }
}
