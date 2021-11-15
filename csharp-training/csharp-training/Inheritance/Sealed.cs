using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Inheritance
{
    public class Sealed : Dervied_Abstract
    {
        public sealed override void GetFoo()
        {
            
        }
    }

    public class Derived_Sealed : Sealed
    {
        //public override void GetFoo() //error sealed
        //{

        //}
    }

    public sealed class SealedClass { }

    //public class Derived_Sealed_Class : SealedClass { }  -- error

}
