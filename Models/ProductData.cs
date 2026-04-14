using System;
using System.Collections.Generic;
using System.Text;

namespace Playwright_Framework.Models
{
    public class ProductData
    {
        public string? Title { get; set; }
        public string? Description { get; set; } 

        public string? Category { get; set; } 
        public decimal? Rating { get; set; }

        public decimal? OldPrice { get; set; }

        public decimal? ActualPrice { get; set; }
    }
}
