
using Playwright_Framework.Models;
using Playwright_Framework.Utilities;

namespace Playwright_Framework.TestDataProviders
{
    public static class CartTestDataProvider
    {
        public static IEnumerable<object[]> CartRegressionCases
        {
            get
            {
                var testCases = TestDataLoader.Load<List<CartTestCase>>(
                    Path.Combine("TestData", "Cart", "cartRegression.json"));

                return testCases.Select(testCase => new object[] { testCase });
            }
        }
    }
}
