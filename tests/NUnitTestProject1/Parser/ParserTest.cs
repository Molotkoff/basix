using NUnit.Framework;
using Basix.Parser;
using System;

namespace Tests
{
    public class ParserTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Check_Parser_Works()
        {
            try
            {
                new Parser().Parse("let i55 = 5 * 10 - 6");
            }
            catch (Exception e)
            {
                Assert.Fail();
            }

            Assert.Pass();
        }
    }
}