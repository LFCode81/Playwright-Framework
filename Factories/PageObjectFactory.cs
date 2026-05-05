using Microsoft.Playwright;
using Playwright_Framework.Pages;

namespace Playwright_Framework.Factories
{
    public class PageObjectFactory( IPage page )
    {
        private readonly IPage _page = page;

        public HomePage Home => new(_page);
        public SearchResultsPage SearchResults => new(_page);
        public ShoppingCartPage ShoppingCart => new(_page);
        public CategoryPage Category => new(_page);
        public ProductDetailsPage ProductDetails => new(_page);

        public WishListPage WishList => new(_page);

        public LoginPage Login => new(_page);

        
        public RegisterPage Register => new(_page);

    }
}
