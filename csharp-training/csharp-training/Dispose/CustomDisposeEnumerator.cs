using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Dispose
{
    public class CustomDisposeEnumerator : IEnumerable<Dispose>, IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Dispose");
        }

        public IEnumerator<Dispose> GetEnumerator()
        {
            throw new Exception();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new Exception();
        }
    }
}
