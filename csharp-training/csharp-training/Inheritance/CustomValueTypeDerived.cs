using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Inheritance
{
    //public struct CustomValueTypeDerived : CustomValueTypeBase // error - value type can't inherit by another value type
    //public struct CustomValueTypeDerived  : CustomClass // error
    public struct CustomValueTypeDerived : ICustomValueTypeInterface
    {
    }
}
