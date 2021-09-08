using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Models
{
    public readonly struct ReadOnlyStruct
    {
        //public int MyProperty { get; set; } //error
        public readonly int MyProperty { get; }

    }
}

// readonly struct can be optimized by c#. If compiler know that this type will be immutable then it is possible to don't make a copy and use same instance.
// 

