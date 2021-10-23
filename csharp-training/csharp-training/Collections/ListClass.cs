using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Models
{
    public class ListClass
    {
        public void Method_001()
        {
            var list = new List<int>(20);
            var list1 = new List<int>();
            list1.Add(1);
            list1.TrimExcess();
            int[] array = { 1, 2, 3, 4 };

            var list2 = new List<int>(array);
            var list3 = new List<int>() { 1, 2, 3 };
        }
    }
}
