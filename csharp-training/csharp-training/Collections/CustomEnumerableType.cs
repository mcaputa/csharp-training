using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Collections
{
    public class CustomEnumerableType<T> : IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
