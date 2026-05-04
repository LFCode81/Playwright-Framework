
using System.Reflection;
using Playwright_Framework.Models;
using Playwright_Framework.Utilities;

namespace Playwright_Framework.TestDataProviders
{
    public static class SearchTestDataProvider
    {
        public static IEnumerable<object[]> SearchRegressionCases
        {
            get
            {
                var testCases = TestDataLoader.Load<List<SearchTestCase>>(
                    Path.Combine("TestData", "Search", "SearchRegression.json"));

                return testCases.Select(testCase => new object[] { testCase });
            }
        }

        public static string GetSearchRegressionCaseName(MethodInfo methodInfo, object[] data)
        {
            var testCase = (SearchTestCase)data[0];

            return $"{methodInfo.Name}: {testCase.SearchTerm} | ShouldHaveResults={testCase.ShouldHaveResults}";
        }
    }
}
