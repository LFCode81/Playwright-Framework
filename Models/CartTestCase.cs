using System;
using System.Collections.Generic;
using System.Text;

namespace Playwright_Framework.Models
{
    public class CartTestCase
    {
        public string Category { get; set; } = string.Empty;

        public string? SubCategory { get; set; }

        public string ProductName { get; set; } = string.Empty;
        public string ExpectedPrice { get; set; } = string.Empty;
    }
}
