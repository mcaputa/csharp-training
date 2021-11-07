using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace csharp_training.Inheritance
{
    public class Base
    {
    }

    public class Derived : Base
    {

    }

    public class Another
    {
        public void Main()
        {
            var derived = new Derived();
            UseBase(derived);

            var derivatives = new List<Derived>() { new Derived() };
            AllYourBase(derivatives); //its work because IEnumerable declares T parameteras covariant.
      

            //AddBase(derivatives); //error 

            var bases = new List<Base>();

            //AllYourDerivatives(bases); //error contravariant only from derived to base

            var animalComparer = new AnimalComparer();
            var catsComparer = new CatsComparer();

            CompareCats(catsComparer);

            CompareCats(animalComparer); // contravatriant can use base when require derived

        }

        public void UseBase(Base b)
        {

        }

        public void AllYourBase(IEnumerable<Base> bases)
        {

        }

        public void AllYourDerivatives(IEnumerable<Derived> deriveds)
        {

        }

        public void CompareCats(IComparer<Cat> cats)
        {
            cats.Compare(new Cat(), new Cat());
        }

        public void AddBase(ICollection<Base> bases)
        {
            bases.Add(new Base());
        }


    }

    public class Animal {}
    public class Cat : Animal {}

    public class AnimalComparer : IComparer<Animal>
    {
        public int Compare([AllowNull] Animal x, [AllowNull] Animal y)
        {
            throw new NotImplementedException();
        }
    }

    public class CatsComparer : IComparer<Cat>
    {
        public int Compare([AllowNull] Cat x, [AllowNull] Cat y)
        {
            throw new NotImplementedException();
        }
    }

}
