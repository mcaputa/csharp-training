using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace csharp_training.Models
{
    public class Destructor
    {
        ~Destructor()
        {
            Trace.WriteLine("End of object");
        }
    }
}
