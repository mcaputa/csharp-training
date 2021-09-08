using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Models
{
    public class ConstructorClass
    {
        //private int Year = GetYear(); - if you want to use method it have to be static
        private int Year;

        public static readonly string Town;

        public ConstructorClass(int age, string name)
        {
            Year = GetYear();
            //Town = "Wrocław"; - error, readonly can be initialized only in static constructor.
        }

        private int GetYear()
        {
            return DateTime.Now.Year;
        }
    }
}
