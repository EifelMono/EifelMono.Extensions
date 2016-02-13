using NUnit.Framework;
using System;
using System.Collections.Generic;
using EifelMono.Extensions;
using System.Diagnostics;
using System.Security.Policy;

namespace EifelMono.Extensions.Test
{
    [TestFixture()]
    public class TestBoolean
    {
        [Test()]
        public void TestBoolean1()
        {
            First running = new First();

            Assert.IsTrue(running.IsFirst);
            Assert.IsFalse(running.IsFirst);
            Assert.IsFalse(running.IsFirst);
            Assert.IsFalse(running.IsFirst);
            Assert.IsFalse(running.IsFirst);
          
            running.Reset();

            Assert.IsTrue(running.IsFirst);
            Assert.IsFalse(running.IsFirst);
            Assert.IsFalse(running.IsFirst);
            Assert.IsFalse(running.IsFirst);
            Assert.IsFalse(running.IsFirst);
        }
    }
}

