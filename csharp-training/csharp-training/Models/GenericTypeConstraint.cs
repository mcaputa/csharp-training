using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace csharp_training.Models
{
    public class GenericTypeConstraint<T> : IComparer<T> where T : IComparable<T>
    {
        public int Compare([AllowNull] T x, [AllowNull] T y)
        {
          return x.CompareTo(y);
        }
    }
}
