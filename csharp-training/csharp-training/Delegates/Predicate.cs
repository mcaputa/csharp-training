using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training.Delegates
{
    public class Predicate
    {
        public void Main()
        {
            Predicate<int> predicate = IsGraterThanZero; // method group        
            Action<int, string> action = GetResult;
            Func<int, DateTime, bool> func = GetBool;
        }

        public bool GetMultiPredicateResult()
        {
            Predicate<int> multiPredicate = IsGraterThanZero;
            multiPredicate += IsGraterThanOne;
            multiPredicate += IsGraterThanHunderd;

            return multiPredicate(10); // only last delegate return result. Other result are ignored.
        }
        public bool IsGraterThanZero(int number)
        {
            return false;
        }

        public bool IsGraterThanOne(int number)
        {
            return false;
        }

        public bool IsGraterThanHunderd(int number)
        {
            return true;
        }

        public void GetResult(int number, string name)
        {

        }

        public bool GetBool(int number, DateTime date)
        {
            return true;
        }

    }

   
}
