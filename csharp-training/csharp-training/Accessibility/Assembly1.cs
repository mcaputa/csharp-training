using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Accessibility
{
    public class Assembly1
    { 
        protected internal int protectedInternal = 10;
        internal string internalProperty = "MC";
        private protected int privateProtected = 29;
        protected bool isProtected = true;
    }

    public class Derived : Assembly1
    {
        public void Main()
        {
            var assembly1 = new Assembly1();
            assembly1.protectedInternal = 10; //work only with internal
            //assembly1.isProtected // error
            //assembly1.age //error
            privateProtected = 30;
            var derived = new Derived();
            derived.protectedInternal = 10;
            derived.privateProtected = 29;
            derived.isProtected = true;
            isProtected = true;
            
        }
    }

    public class Another
    {
        public void Main()
        {
            var derived = new Derived();
            derived.protectedInternal = 10;
        }
    }


}
