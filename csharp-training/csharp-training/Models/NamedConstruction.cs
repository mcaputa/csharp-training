using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Models
{
    public class NamedConstruction<T>
    {
        public T Item { get; set; }

        public NamedConstruction(T item)
        {
            Item = item;
        }
    }
}
