using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Delegates
{
    public class AnonymousFunctions
    {
        public void Main()
        {
            Predicate<int> lambda = value => value > 0; //lambda 
            Func<string, string, int> lambda1 = (string name, string age) => { return 10; };
            Action<int> lambda2 = value => Console.WriteLine(value);
            Action<int> lambda3 = value => { };
            Func<bool> lambda4 = () => true;


            Func<int, bool> annonymousMethod = delegate (int value) { // anonymouse method
                return true;
            };
        }
    }
}
