using csharp_training.Collections;
using csharp_training.Directives;
using csharp_training.Model;
using csharp_training.Models;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace csharp_training_tests
{
    [TestFixture]
    class BasicCodingTests
    {
        [Test]
        public void Variables_When_Test_Then_ReturnResult_001()
        {
            //given
            string myName = "Maciek";
            //int age = "27" - compile error
            var age = 27; //compiler discover it is int 
            string stringTypeWithoutInitialization;

            stringTypeWithoutInitialization = "initialization after declaration";

            //var variableWithoutInitialization - compiler error - with var keyword must be initialization

            var currentDate = new DateTime();

            //currentDate = ""; - compiler error

            double a = 1, b = 2.5, c = -3;
            //string cityA = "Boston", cityB = "Warsaw", cityC = 12; - compile error

            //var d = 5, e = 1, f = 3; - compiler error

            int willNotWork;

            //Console.WriteLine(willNotWork); - compiler error   

            //when
            //then
            age.Should().BeOfType(typeof(int));
        }

        [Test]
        public void GetVariable_When_Scope_Then_CheckResult_002()
        {
            //given
            int myAgeParentMethod = 12;
            //Console.WriteLine(myName); -compiler error - "myName" doesn't exist in current scope
            void InitVariable()
            {
                int myAge = 50;
            }

            void UseVariable()
            {
                //Console.WriteLine(myAge); // compiler error
                Console.WriteLine(myAgeParentMethod);
            }

            if (myAgeParentMethod > 12)
            {
                Console.WriteLine(myAgeParentMethod);
                int youngerMe = myAgeParentMethod - 4;
            }

            //Console.WriteLine(youngerMe); - compiler error


            //when
            //then
            Assert.Pass();
        }

        [Test]
        public void CheckResult_WhenDeclareSameNameVariableInLocalScope_Then_Error_003()
        {
            //given

            if (true)
            {
                //var city = "Warsaw"; - compiler error, c# dissallow duplicate name of variables to misunderstanding
            }

            var city = "Wroclaw";
            //when
            //then
            Assert.Pass();
        }

        [Test]
        public void KindOfStatements_004()
        {
            //given
            int a = 19; // declaration statement
            int b = 2; // declaration statement
            int c;      //declaration statement
            c = a + b; // expression s  tatements
            Console.WriteLine(c); // expression statements

            for (int i = 0; i < c; i++)  // iteration statement
            {

            }

            if (true) // selection statement
            {

            }

            switch (c) // selection statement
            {
                default:
                    break;
            }

            //when
            //then
            Assert.Pass();
        }

        [Test]
        public void KindOfExpressions_005()
        {
            //given
            string a = "Hello World"; // expressions => literals
            int b = 42; //expressions => literals
            //+ - operator
            b++; // b - operand, ++ operator
            //2 + 2; // 2 is literal expression , 2 + 2 is expressions, 2 is literal expression.
            var c = (a + b); // parenthesize expression

            // 2 + 2; //no statement
            Math.Sqrt(2); // statement, because of e.g. Console.ReadKey()

            //when
            //then
            Assert.Pass();
        }

        [Test]
        public void Comments_006()
        {
            //given


            /*
             * delimited comment
             */

            Console.WriteLine(/*"delimited comment"*/ "test");
            //when
            //then
        }
        #region test directives
        [Test]
        [System.Diagnostics.Conditional("DEBUG")] //can be instead #if #else. Compiler will omit call this method. 
        public void Directives_007()
        {
            //given
#if DEBUG 
            Console.WriteLine("debug");
#else 
            Console.WriteLine("release");
#endif

            var subs = Substitute.For<ConditionalMethod>();
#pragma warning disable CS0168
            int a;

            //when
            subs.Main();

            //then
            subs.result.Should().Be("release");
            Debug.Assert(subs.result == "debug");
            Assert.Pass();
        }
        #endregion

        [Test]
        public void Switch_007()
        {
            //given
            string caseInput = "1";
            int caseNumber = 1;
            //when

            switch (caseInput)
            {
                case "1":
                    Trace.WriteLine("case 1");
                    break;
                case "2":
                case "3":
                    Trace.WriteLine("case 2 or 3");
                    break;
                default: // can be ignored
                    Trace.WriteLine("default");
                    break;
            }

            switch (caseNumber)
            {
                case int number when (number > 100):
                    break;
            }

            switch (caseNumber)
            {
                default:
                    return;
            }
           
            //then
            Assert.Pass();
        }

        [Test]
        public void ForEach_008()
        {
            //given
            var enumerableType = new CustomEnumerableType<int>();
            //when

            foreach (int item in enumerableType)
            {
                //ignore
            }

            //then
            Assert.Pass();
        }

        [Test]
        public void Patterns_009()
        {
            //given
            var caseNumber = "test";
            (int X, int Y) p = (0, 0);
            object t = "test";

            //when
            switch (caseNumber)
            {
                case "test": // constant pattern
                    break;
            }

            switch (p)
            {
                case (0, 0): // tuple pattern
                    break;
                case (0, int y):
                    Trace.WriteLine($"x:0, y{y}");
                    break;
                case (1, _): //discard pattern
                    Trace.WriteLine($"x:1, y: don't care");
                    break;
                case (int x, int y): //positional pattern
                    Trace.WriteLine($"{x}, {y}");
                    break;
                //case (string x, string y): //error
                //    break;
            }

            switch (t)
            {
                case string { Length: 5 }:
                case string { Length: 0 }: // property pattern
                    break;
                case string s: //type pattern
                    Trace.WriteLine(s);
                    break;
                case int i:
                    Trace.WriteLine((i + 1));
                    break;
                case ModelPropertyPattern { Age: int age,  Name: "MC" } me: //property pattern with output
                    Trace.WriteLine($"{me.Name}, {age}");
                    break;
                case ModelPropertyPattern me when me.Age >= 27 && me.Name == "MC" : //when clause
                    Trace.WriteLine($"{me.Name}, {me.Age}");
                    break;
                case bool _: //discard variable
                    break;
            }

            var v = p switch
            {
                (int x, int y) when y > x => "y > x",
                (int x, int y) when y < x => "y < x",
                (int x, int y) when y == x => "y < x",
                _ => throw new NotImplementedException(),
            };


            //then

            Assert.Pass();
        }

        [Test]
        public void Nullable_010()
        {
            //given
            Nullable<int> a = null;
            int? b = 10;

            var result = a + b;

            result.Should().BeNull();

            int c = 10;
            result = c + a;
            result.Should().BeNull();

            string? referenceFromLegacyComponent = GetLegacyReference();

            string nonNullableReferenceFromLegacyComponent = referenceFromLegacyComponent!; // null forgiving operator

            //when
            //then
            Assert.Pass();
        }

        [Test]
        public void Out_011()
        {
            //given

            //when
            var result = Divide(10, 3, out int r); 

            //then
            r.Should().Be(1);
        }

        [Test]
        public void Ref_012()
        {
            //given
            //when
            var test = new RefClass() {
                Name = "Maciek"
            };

            var test1 = new RefClass()
            {
                Name = "Maciek1"
            };

            ReplaceRefClass(ref test);
            ReplaceRefClass(test1);

            //then
            test.Name.Should().Be("Maciek2");
            test1.Name.Should().Be("Maciek1");
        }

        [Test]
        public void StringExtensionMethods_013()
        {
            //given
            //when
            var result = "test".Show();

            //then
            result.Should().Be("Default value : test");
        }

        [Test]
        public void NullConditionalIndexAccess_014()
        {
            //given
            int[]? arr = null;
            //when
            var result = arr?[5];

            //then
            result.Should().BeNull();
        }

        [Test]
        public void CustomOperators_015()
        {
            //given
            var counter = new Counter();
            counter.AddNext();
            //when
            var result = counter + "1";

            //then
            result.Should().Be(2);
        }

        [Test]
        public void CustomExplicityImplicity_016()
        {
            //given
            //when
            Counter x = 153;
            int y = (int) x;

            //then
            x.GetValue().Should().Be(153);
            y.Should().Be(153);
        }

        [Test]
        public void GenericTest_017()
        {
            //given

            //when
            var item = new NamedConstruction<object>(new object());
            var item2 = new NamedConstruction<string>("test");

            //then
            //item = item2; // error
        }

        [Test]
        public void GenericConstraintTest_018()
        {
            //given
            //when
            var test = new GenericConstraints<int>();
            //var test2 = new GenericConstraints<string>(); //error
            //var test2 = new GenericConstraints<ParameterLessConstructor>(); // error

            //then
        }

        [Test]
        public void CheckIListParameterTest_019()
        {
            //given
            var customGenericIList = new CustomGenericIListClass<int>();        
            var list = new List<int>();
            //when
            //then
            //RequireNonGenericIList(customGenericIList); //error
            RequireNonGenericIList(list);

            RequireGenericIList(customGenericIList);
            RequireGenericIList(list);
        }
        [Test]
        public void CallAddMethodOnArray_020()
        {
            //given
            int[] arr = new int[4] { 1,2,3,4 };
            IList<int> iList = arr;

            iList.Add(5); //System.NotSupportedException : Collection was of a fixed size.

            //when
            //then
        }

        [Test]
        public void YieldTests_021()
        {
            //given
            var numbers = new List<int>();
            var persons = new List<Person>();
            var names = new List<string>();


            //when
            var yieldClass = new YieldClass();

            IEnumerable<int> enumerableNumbers = yieldClass.ReturnValueFromLoop();
            IEnumerable<Person> enumerablePerson = yieldClass.ReturnPersonDetails();
            //IEnumerable<string> enumarablePersonName = yieldClass.GetPersonsName(); 

            foreach (var number in enumerableNumbers)
            {
                numbers.Add(number);
            }

            foreach (var person in enumerablePerson)
            {
                persons.Add(person);
            }

            //foreach (var name in enumarablePersonName) 
            //{
            //    names.Add(name);
            //}

            //then

            numbers.Should().BeEquivalentTo(new[] { 0, 1, 2, 3, 4 });
            persons.Select(x => x.Name).Should().BeEquivalentTo(new string[] { "Bob", "John", "Garry" });
            //names.Should().BeEquivalentTo(new string[] { "Tom", "Jerry", "Julia" });

        }

        [Test]
        public void DictionaryTests_22()
        {
            //given
            //when
            var dictionary = new Dictionary<string, int>();
            foreach (KeyValuePair<string, int> row in dictionary)
            {
            }

            var dict = new Dictionary<string, string>()
            {
                { "Maciek", "Wroclaw" },
            };

            var dict2 = new Dictionary<string, string>()
            {
                ["Maciek"] = "Wroclaw"
            };

            var sortedDictionary = new SortedDictionary<string, int>()
            {
                {"Maciek", 27 },
                {"Ala", 19 }
            };

            //var ok = sortedDictionary.Keys[2]; //error

            foreach (var item in sortedDictionary)
            {

            }

            var sortedDictionaryList = new SortedList<string, int>()
            {
                {"Maciek", 27 },
                {"Ala", 19 }
            };

            var result = sortedDictionaryList.Keys[1];


            //then

            result.Should().Be("Maciek");
        }

        [Test]
        public void SetsTests_23()
        {
            //given
            //when
            var hashSet = new HashSet<string>()
            {
                "maciek",
                "kuba"
            };
            
            //var result = hashSet[5]; //error

            //then
        }

        [Test]
        public void QueueAndStackTests_24()
        {
            //given
            var queue = new Queue<int>();
            queue.Enqueue(1); // first to dequeue
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4); // last in queue

            var stack = new Stack<string>();
            stack.Push("1"); // last
            stack.Push("2");
            stack.Push("3"); // pop first


            //when
            foreach (var item in queue)
            {               
            }


            //then
            queue.Dequeue().Should().Be(1);
            stack.Pop().Should().Be("3");
        }

        [Test]
        public void ImmutableDictionary_025()
        {
            //given
            var immutableDictionary = ImmutableDictionary.Create<int, string>();
            immutableDictionary = immutableDictionary.Add(1, "One");
            //when

            //then
        }

        public void RequireNonGenericIList(IList list)
        {

        }

        public void RequireGenericIList<T>(IList<T> list)
        {

        }

        public void ReplaceRefClass(RefClass refClass)
        {
            refClass = new RefClass()
            {
                Name = "Maciek3"
            };
        }

        public void ReplaceRefClass(ref RefClass refClass) //ref on reference type allow to replace object which you pass
        {
            refClass = new RefClass()
            {
              Name = "Maciek2"
            };
        }

        private int Divide(int x, int y, out int reminder) // reminder is a reference to r in 011
        {
            reminder = x % y;
            return x / y;
        }

        private string? GetLegacyReference()
        {
            return string.Empty;
        }
    }
}
