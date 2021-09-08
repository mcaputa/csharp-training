using csharp_training.Models;
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
    }
}
