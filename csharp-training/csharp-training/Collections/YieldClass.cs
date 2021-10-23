using csharp_training.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Collections
{
    public class YieldClass
    {
        private List<Person> Persons = new List<Person>()
        {
            new Person() { Age = 10, Name = "Tom" },
            new Person() { Age = 15, Name = "Jerry" },
            new Person() { Age = 20, Name = "Julia" },
        };

        private int Iterator { get; set; }

        public IEnumerable<int> ReturnIEnumerable() // you can return IEnumerable,IEnumerator, generic and async IEnumerable and IEnumerator
        {
            yield return 1;
        }

        public IEnumerable<int> ReturnValueFromLoop()
        {
            for (int i = 0; i < 5; i++)
            {
                var a = i;
                yield return i;
                Console.WriteLine($"Last a was {a}");
            }
        }

        public IEnumerable<Person> ReturnPersonDetails()
        {
            yield return new Person() { Age = 10, Name = "Bob" };
            yield return new Person() { Age = 15, Name = "John" };
            yield return new Person() { Age = 20, Name = "Garry" };

        }

        //public IEnumerable<string> GetPersonsName() // know i understand yield :)
        //{
        //    if (Iterator == 3)
        //    {
        //        yield break;
        //    }

        //    yield return Persons[Iterator].Name;
        //    Iterator++;
        //}
    }
}
