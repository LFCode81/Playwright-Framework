using System;
using System.Collections.Generic;
using System.Text;

namespace Playwright_Framework.Models
{
    public class PlaywrightSettings
    {
        public bool Headless { get; set; }
        public int SlowMo { get; set; }
        public string Browser { get; set; } = "Chromium";
    }
}
