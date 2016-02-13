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

        [Test()]
        public void TestBoolean2()
        {
            var running = new First<string>();

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

            Assert.IsTrue(string.IsNullOrEmpty(running.Value));
            Assert.IsTrue(string.IsNullOrEmpty(running.DefaultValue));

            running.Value = "abc";
            Assert.IsTrue(running.Value == "abc");
            running.Reset();
            Assert.IsTrue(string.IsNullOrEmpty(running.DefaultValue));
            Assert.IsTrue(running.Value == "abc");
            running.Reset(true);
            Assert.IsTrue(string.IsNullOrEmpty(running.Value));
            Assert.IsTrue(string.IsNullOrEmpty(running.DefaultValue));
        }


        [Test()]
        public void TestBoolean3()
        {
            var running = new First<string>("abcde");

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

            Assert.IsTrue(running.Value == "abcde");
            Assert.IsTrue(running.DefaultValue == "abcde");

            running.Value = "abc";
            Assert.IsTrue(running.Value == "abc");
            running.Reset();
            Assert.IsTrue(running.Value == "abc");
            Assert.IsTrue(running.DefaultValue== "abcde");
            running.Reset(true);
            Assert.IsTrue(running.Value == "abcde");
            Assert.IsTrue(running.DefaultValue == "abcde");
        }

        [Test()]
        public void TestBoolean4()
        {
            var running = new First<string>("abcde");

            Assert.IsTrue(running.IsFirst);
            Assert.IsFalse(running.IsFirst);
            Assert.IsFalse(running.IsFirst);
            Assert.IsFalse(running.IsFirst);
            Assert.IsFalse(running.IsFirst);

            running.Reset(true);

            Assert.IsTrue(running.IsFirstOrEqlValue("abcdef"));
            Assert.IsTrue(running.Value== "abcdef");
            Assert.IsTrue(running.IsFirstOrEqlValue("abcdef"));
            Assert.IsTrue(running.Value== "abcdef");
            Assert.IsFalse(running.IsFirstOrEqlValue("abcd"));
            Assert.IsTrue(running.Value== "abcd");
            Assert.IsFalse(running.IsFirstOrEqlValue("abcde", false));
            Assert.IsTrue(running.Value== "abcd");
            Assert.IsTrue(running.IsFirstOrNotEqlValue("abcdef", false));
            Assert.IsTrue(running.Value== "abcd");
            Assert.IsFalse(running.IsFirstOrNotEqlValue("abcd", true));
            Assert.IsTrue(running.Value== "abcd");

        }
    }
}

