using System;
using System.Collections.Generic;
using System.Text;

namespace Playwright_Framework.Models
{
    public class SearchTestCase
    {
        string TestCaseName { get; set; } = string.Empty;
        public string SearchTerm { get; set; } = string.Empty;
        public bool ShouldHaveResults { get; set; }

        public string? ExpectedFirstResult { get; set; }
        public int? ExpectedMinResults { get; set; }
    }
}
