using csharp_training.Models;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training_tests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void Test_Constructor_001()
        {
            //given

            //when
            //var test1 = new ConstructorClass(); -error, need two parameters
            var test2 = new ConstructorStruct(); // that struct don't have decalred parameterless ctor and it's working. 
            //then
        } 

        [Test]
        public void Test_Constructor_002()
        {
            //given
            //when
            //then
            ConstructorClass.a.Should().Be(1); // when a object with static fields is creating then all static fields are set to default value and after that initialization is invoke. 
            ConstructorClass.b.Should().Be(42);
            ConstructorClass.c.Should().Be(43);
        }

        [Test]
        public void TestConstructor_003()
        {
            //given
            Console.WriteLine("Start");
            //when
            var obj = new ConstructorClass(20, "Maciek");
            
            Console.WriteLine("Finish");
            //then
        }
    }
}
