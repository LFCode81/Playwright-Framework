using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Playwright;
using Playwright_Framework.Components;

namespace Playwright_Framework.Pages
{
   public class SearchResultsPage( IPage page ) : BasePage(page)
    {

        public ILocator SearchResultsTitle => Page.Locator(".page-title");
        public ILocator NoResultsMessage => Page.GetByText("No products were found that");
        public ILocator SearchLengthMessage => Page.GetByText("Search term minimum length is 3 characters");

        public ILocator AdvancedSearch => Page.GetByRole(AriaRole.Checkbox, new() { Name = "Advanced search" });

        public ILocator SearchKeyword => Page.GetByRole(AriaRole.Textbox, new() { Name = "Search keyword:" });

        public ILocator ProductGrid => Page.Locator(".product-grid");
        public ILocator ProductItems => ProductGrid.Locator(".product-item");


        public async Task<bool> HasResultsAsync()
        {

            if( await ProductItems.CountAsync()  > 0 ) 
                return true;
            
            return false;
        }

        public async Task<int> GetProductCountAsync()
        {
            await ProductItems.First.WaitForAsync();
            return await ProductItems.CountAsync();
        }
    }
}
