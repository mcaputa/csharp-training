using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace csharp_training_tests
{
    [TestFixture]
    public class ExceptionsTests
    {
        [Test]
        public void MultiCatch_Tests_001()
        {
            //given
            string message = string.Empty;
            try
            {
                using (StreamReader r = new StreamReader(@$"{Environment.CurrentDirectory}\File.txt"))
                {
                    while (!r.EndOfStream)
                    {
                        Console.WriteLine(r.ReadLine());
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                message = "file ex";
            }
            catch(IOException ex)
            {
                message = "io exception";
            }
            //when
            //then

            message.Should().Be("file ex");
        }

        [Test]
        public void MultiCatch_Revers_Tests_002()
        {
            //given
            string message = string.Empty;
            try
            {
                using (StreamReader r = new StreamReader(@$"{Environment.CurrentDirectory}\File.txt"))
                {
                    while (!r.EndOfStream)
                    {
                        Console.WriteLine(r.ReadLine());
                    }
                }
            }
            catch (IOException ex)
            {
                message = "io exception";
            }
            //catch (FileNotFoundException ex) //error
            //{
            //    message = "file ex";
            //}
            
            //when
            //then

            message.Should().Be("io exception");
        }

        [Test]
        public void Exceptions_Bubbling_003()
        {
            //given
            //when 
            string result = string.Empty;
            try
            {
                try
                {
                    try
                    {
                        throw new ArgumentException("test");
                    }
                    catch (FileNotFoundException)
                    {
                         result = "file";
                    }
                }
                catch (ArgumentException ex)
                {
                    result = "argument";
                }
            }
            catch (Exception)
            {
                result = "ex";
            }

            //then

            result.Should().Be("argument");
        }

        [Test]
        public void FinallyBlock_When_Ex_004()
        {
            //given
            var result = string.Empty;
            //when
            try
            {
                try
                {
                    try
                    {
                        throw new Exception();
                    }
                    catch (Exception)
                    {
                        result = "ex";
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            finally 
            {
                result = "finally";
            }
            //then
            result.Should().Be("finally");
        }

        [Test]
        public void ReThrowingException_005()
        {
            //given
            var expectedException = "arg ex";
            var secondCatch = string.Empty;
            //when
            try
            {
                try
                {
                    throw new ArgumentException(expectedException);
                }
                catch (Exception ex)
                {
                    throw ex; // with that approach we lose stack trace. .net think we start brand new exception.
                }
            }
            catch (Exception ex)
            {
                secondCatch = ex.Message;                
            }

            //then
            secondCatch.Should().Be(expectedException);
        }
    }
}
