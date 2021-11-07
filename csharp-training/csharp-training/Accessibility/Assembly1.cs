using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Accessibility
{
    public class Assembly1
    { 
        protected internal int myValue = 10;
        internal string name = "MC";
        private protected int age = 29;
        protected bool isProtected = true;
    }

    public class Derived : Assembly1
    {
        public void Main()
        {
            var assembly1 = new Assembly1();
            assembly1.myValue = 10; //work only with internal
            //assembly1.isProtected // error
            age = 30;
            var derived = new Derived();
            derived.myValue = 10;
            derived.age = 29;
            derived.isProtected = true;
            isProtected = true;
            
        }
    }


}
