using System;
using System.Collections.Generic;
using System.Text;

namespace Playwright_Framework.Utilities
{
    public static class TestDataHelpers
    {
        public static class TestData
        {
            public static string UniqueEmail(string prefix = "test")
            {
                return $"{prefix}+{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}-{Guid.NewGuid():N}@example.com";
            }
            public static string UniquePassword()
            {
                return $"P@ss-{Guid.NewGuid():N}1!";
            }

        }

    }
}
