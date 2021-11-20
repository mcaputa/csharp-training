using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Dispose
{
    public class Dispose : IDisposable
    {
        public void Run()
        {

        }
        void IDisposable.Dispose()
        {
            Console.WriteLine("Dispose");
        }
    }
}
