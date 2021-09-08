using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Models
{
    public class StaticConstructor
    {
        //public static StaticConstructor(int age ) { } // error

        public static readonly int Age;

        static StaticConstructor()
        {
            Age = 10;
        }
    }
}
