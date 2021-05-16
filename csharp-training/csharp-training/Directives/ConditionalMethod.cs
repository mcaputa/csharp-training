using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Directives
{
    public class ConditionalMethod
    {
        public string result { get; set; } = "release";
        public void Main()
        {
            ReturnDebugInfo();
        }

        [System.Diagnostics.Conditional("DEBUG")]
        public void ReturnDebugInfo()
        {
            result = "debug";
        }   
    }
}
