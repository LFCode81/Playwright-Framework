using Microsoft.Playwright;
using Playwright_Framework.Pages;

namespace Playwright_Framework.Factories
{
    public class PageObjectFactory( IPage page)
    {
        private readonly IPage _page = page;

        public HomePage Home => new(_page);


        public T Create<T>() where T : BasePage
        {
            return (T)Activator.CreateInstance(typeof(T), _page)!;
        }
    }
}
