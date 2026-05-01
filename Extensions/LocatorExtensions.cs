using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Playwright;

namespace Playwright_Framework.Extensions
{
    public static class LocatorExtensions
    {

        public static async Task<int> CountAsyncSafe(this ILocator locator, int timeout = 5000)
        {
            try
            {
                await locator.First.WaitForAsync(new()
                {
                    Timeout = timeout
                });
            }
            catch
            {
                // No elements found — safe to ignore
            }

            return await locator.CountAsync();

        }

        public static async Task<bool> HasAnyAsync(this ILocator locator)
        {
            return await locator.CountAsyncSafe() > 0;
        }

        public static async Task ClickAsyncSafe(this ILocator locator, int timeout = 5000)
        {
            await locator.WaitForAsync(new()
            {
                State = WaitForSelectorState.Visible,
                Timeout = timeout
            });

            await locator.ClickAsync();
        }

    }
}
