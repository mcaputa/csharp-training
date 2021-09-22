using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Models
{
    public class Counter
    {
        private int _counter;
        private static int _totalCount;
        public void AddNext()
        {
            var _counter = 0;
            this._counter += 1;
            _totalCount += 1;
        }

        public int GetValue()
        {
            return _counter;
        }

        public static int TotalCount => _totalCount;

        public static Counter operator +(Counter x, Counter y)
        {
            return new Counter() { _counter = x._counter + y._counter };
        }

        public static Counter operator +(Counter x, int y)
        {
            x._counter = x._counter + y;
            return x;
        }

        public static int operator +(Counter x, string y)
        {
            return x._counter + int.Parse(y);
        }

        public static explicit operator int(Counter x)
        {
            return x._counter;
        }

        public static implicit operator Counter(int number)
        {
            return new Counter() { _counter = number };
        }
    }
}
