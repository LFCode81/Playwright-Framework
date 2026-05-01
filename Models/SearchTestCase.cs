using System;
using System.Collections.Generic;
using System.Text;

namespace Playwright_Framework.Models
{
    public class SearchTestCase
    {
        public string SearchTerm { get; set; } = string.Empty;
        public bool ShouldHaveResults { get; set; }
    }
}
