using Microsoft.Playwright;
using Playwright_Framework.Factories;
using Playwright_Framework.Pages;
using Playwright_Framework.Utilities;

namespace Playwright_Framework.Fixtures
{
    public abstract class TestBase
    {
        protected IPlaywright Playwright = null!;
        protected IBrowser Browser = null!;
        protected IBrowserContext Context = null!;
        protected IPage Page = null!;
        protected PageObjectFactory Pages => new(Page);


        protected async Task<HomePage> NavigateToHomeAsync()
        {
            var home = Pages.Home;
            await home.NavigateAsync();
            return home;
        }

        protected async Task<ProductDetailsPage> NavigateToProductDetailsPageAsync(string categoryName,string productName)
        {
            var home = await NavigateToHomeAsync();
            await home.MenuBar.GoToCategoryAsync(categoryName);

            var categoryPage = Pages.Category;

            return await categoryPage.OpenProductAsync(productName);
        }

        protected async Task<CategoryPage> NavigateToCategoryPageAsync(string categoryName)
        {
            var home = await NavigateToHomeAsync();
            await home.MenuBar.GoToCategoryAsync(categoryName);

            return Pages.Category;
        }

        protected async Task<SearchResultsPage> NavigateToSearchResultsPageAsync(string searchTerm)
        {
            var home = await NavigateToHomeAsync();
            await home.Search.SearchAsync(searchTerm);

            return Pages.SearchResults;
        }

        protected async Task<WishListPage> NavigateToWishlistPageAsync()
        {
            var home = await NavigateToHomeAsync();
            await home.HeaderLinks.GoToWishlistAsync();

            return Pages.WishList;
        }

        protected async Task<LoginPage> NavigateToLoginPageAsync()
        {
            var home = await NavigateToHomeAsync();
            await home.HeaderLinks.GoToLoginAsync();
            return Pages.Login;
        }

        protected async Task<RegisterPage> NavigateToRegisterPageAsync()
        {
            var home = await NavigateToHomeAsync();
            await home.HeaderLinks.GoToRegisterAsync();
            return Pages.Register;
        }

        [TestInitialize]
        public async Task Setup()
        {
            var settings = ConfigReader.Settings;

            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = settings.Headless,
                SlowMo = settings.SlowMo
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
