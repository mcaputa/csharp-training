using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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
            c = a + b; // expression statements
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
    }
}
