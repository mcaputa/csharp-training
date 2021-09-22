using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Models
{
    public class Indexer
    {
        public List<int> numbers => new List<int>()
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        };



        public string this[int index]
        {
            get => index < 5 ? "Foo" : "bar";
        }

        public int this[string name, int age]
        {
            get
            {
                if (name == "Maciek" && age == 27)
                {
                    return 1;
                }

                return 0;
            }
        }
    }
}
