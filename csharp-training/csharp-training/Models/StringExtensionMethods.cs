using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Models
{
    public static class StringExtensionMethods
    {
        public static string Show(this string s)
        {
            return $"Default value : {s}";
        }
    }
}
