using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Accessibility
{
    public class Assembly2 : Assembly1
    {
        public void Main()
        {
            var assembly1 = new Assembly1();
            assembly1.myValue = 10;  // error with protected, work with protected internal
            //assembly1.age //error
            var derived = new Derived();
            //derived.age // erro
            derived.myValue = 10;  //error with protected, work with protected internal
            //derived.isProtected = true //error
            //derived.age =30 //error            
            assembly1.name = "working";
            derived.name = "working";   

        }
    }
}
