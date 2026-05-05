using Microsoft.Playwright;
using Playwright_Framework.Pages;

namespace Playwright_Framework.Components
{
 
    public class ProductToolbarComponent(IPage page) : BasePage(page)
    {
     
        public ILocator SortByDropdown  => Page.Locator("#products-orderby");
        public ILocator DisplayDropdown => Page.Locator("#products-pagesize");
        public ILocator GridViewButton  => Page.Locator("#products-viewmode");
        public ILocator ListViewButton  => Page.Locator(".viewmode-icon.list");  
        public async Task SortByAsync(string visibleText)
        {
            await SortByDropdown.SelectOptionAsync(new SelectOptionValue
            {
                Label = visibleText
            });
        }

        public async Task SetDisplayCountAsync(string visibleText)
        {
            await DisplayDropdown.SelectOptionAsync(new SelectOptionValue
            {
                Label = visibleText
            });
        }

        public async Task SwitchToGridViewAsync()
        {
            await GridViewButton.ClickAsync();
        }

        public async Task SwitchToListViewAsync()
        {
            await ListViewButton.ClickAsync();
        }
    }
}
