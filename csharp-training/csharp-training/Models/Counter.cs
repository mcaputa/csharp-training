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
    }
}
