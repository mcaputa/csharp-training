using csharp_training.Collections;
using csharp_training.Directives;
using csharp_training.Model;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    }
}
