using Microsoft.Playwright;

namespace Playwright_Framework.Components
{
    public class SearchComponent(IPage page)
    {
        private readonly IPage _page = page;

        public ILocator SearchBox => _page.Locator("#small-searchterms");

        public ILocator SearchButton => _page.GetByRole(AriaRole.Button, new() { Name = "Search" });  //Search button


        public async Task SearchAsync(string searchTerm)
        {
            await SearchBox.FillAsync(searchTerm);
            await SearchButton.ClickAsync();
        }

        public async Task ClearSearchAsync()
        {
            await SearchBox.FillAsync(string.Empty);
        }

        public async Task<string> GetSearchTextAsync()
        {
            return await SearchBox.InputValueAsync();
        }
    }
}
