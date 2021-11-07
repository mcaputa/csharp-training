using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Inheritance
{
    //public class A : B //i need to pass argument
    public class A : B <string> 

    {
    }

    public class B<T>
    {
    }

    //public class C : B<B> // error
    public class C : B<C>
    {

    }


}
