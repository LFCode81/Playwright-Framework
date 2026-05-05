using System;
using System.Collections.Generic;
using System.Text;

namespace Playwright_Framework.Extensions
{
    public static class TypeConversionExtensions
    {
        public static int ToInt(this string value)
        {
            return int.Parse(value);
        }

        public static decimal ToDecimal(this string value)
        {
            return decimal.Parse(value);
        }
    }
}
