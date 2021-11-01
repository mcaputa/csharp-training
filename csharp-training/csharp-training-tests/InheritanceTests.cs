using csharp_training.Inheritance;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_training_tests
{
    [TestFixture]
    public class InheritanceTests
    {
        [Test]
        public void InterfaceInheritance_Test_001()
        {
            //given
            //when

            IAnotherInterface test = new CustomClassWithInterfaceInheritance();

            IBaseInterface baseInterface = (IBaseInterface)test;

            var Both = baseInterface as IBoth;

            //then
        }
    }
}
