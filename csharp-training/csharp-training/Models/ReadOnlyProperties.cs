using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Models
{
    public class ReadOnlyProperties
    {
        public readonly string Name;
        public readonly int Age = 27; //only init setter
        //public readonly int Year = GetYear(); error
        public readonly int Year = DateTime.Now.Year;
        public ReadOnlyProperties()
        {
            Name = "Maciek"; // and conctructor
            Age = 28;
        }

        public ReadOnlyProperties(int age, string name)
        {
            Name = name;
            Age = age;
        }

        public void TryToSetValueToReadOnlyField()
        {
            //Name = "Tomek"; - error 
            //Age = 22; - error
        } 

        private int GetYear()
        {
            return DateTime.Now.Year;
        }
    }
}
