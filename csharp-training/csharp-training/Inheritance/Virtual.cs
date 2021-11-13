using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Inheritance
{
    public class Virtual_Base
    {
        public virtual int Virtual { get; set; }
        public virtual void  GetFoo()
        {
        }

        public virtual int GetBoo()
        {
            return default;
        }
    }

    public class Virtual_Derived : Virtual_Base
    {
        public override int Virtual => 10;
        public override void GetFoo()
        {
            //something
        }
    }
}
