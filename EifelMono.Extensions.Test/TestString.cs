﻿using NUnit.Framework;

namespace EifelMono.Extensions.Test
{
    [TestFixture()]
    public class TestString
    {

        [Test()]
        public void TestString1()
        {
            int result = -1;
            string TestValue = "Hugo";

            #region Test 1
            result = -1;
            TestValue = "Hugo";
            TestValue.Switch()
                .Case("Egon", (p) =>
                {
                    result = 0;
                })
                .Case("Hugo", (p) =>
                {
                    result = 1;
                })
                .Default((p) =>
                {
                    result = 2;
                });
            Assert.IsTrue(result == 1);
            #endregion

            #region Test 2
            result = -1;
            TestValue = "Hugo";
            TestValue.Switch()
                .Case("Egon", (p) =>
                {
                    result = 0;
                })
                .CaseStartsWith("Hu", (p) =>
                {
                    result = 1;
                })
                .Case("Hugo", (p) =>
                {
                    result = 2;
                })
                .Default((p) =>
                {
                    result = 3;
                });
            Assert.IsTrue(result == 1);
            #endregion

            #region Test 3
            result = -1;
            TestValue = "Hugo";
            TestValue.Switch()
                .Case("Egon", (p) =>
                {
                    result = 0;
                })
                .CaseStartsWith("Hu")
                .And()
                .CaseStartsWith("Hug", (p) =>
                {
                    result = 1;
                })
                .Default((p) =>
                {
                    result = 2;
                });
            Assert.IsTrue(result == 1);
            #endregion

            #region Test 4
            result = -1;
            TestValue = "Hugo";
            TestValue.Switch()
                .Case("Egon", (p) =>
                {
                    result = 0;
                })
                .CaseStartsWith("Hu")
                .And()
                .CaseStartsWith("Heg", (p) =>
                {
                    result = 1;
                })
                .Default((p) =>
                {
                    result = 2;
                });
            Assert.IsTrue(result == 2);
            #endregion

            #region Test 5
            result = -1;
            TestValue = "Hugo";
            TestValue.Switch()
                .Case("Egon", (p) =>
                {
                    result = 0;
                })
                .CaseStartsWith("Hu")
                .And()
                .CaseStartsWith("Heg", (p) =>
                {
                    result = 1;
                })
                .Case("Hugo", (p) =>
                {
                    result = 2;
                })
                .Default((p) =>
                {
                    result = 3;
                });
            Assert.IsTrue(result == 2);
            #endregion

            #region Test 6
            result = -1;
            TestValue = "Hugo";
            TestValue.Switch()
                .Case("Egon", (p) =>
                {
                    result = 0;
                })
                .CaseStartsWith("Hu")
                .And()
                .CaseStartsWith("Heg", (p) =>
                {
                    result = 1;
                })
                .CaseStartsWith("Hug", (p) =>
                {
                    result = 2;
                })
                .Default((p) =>
                {
                    result = 3;
                });
            Assert.IsTrue(result == 2);
            #endregion
        }

        [Test()]
        public void TestString2()
        {
            Assert.IsTrue("a.b.c.d.e".DotFirst()== "a");
            Assert.IsTrue("a.b.c.d.e".DotFirst(2)== "a.b");
            Assert.IsTrue("a.b.c.d.e".DotFirst(3)== "a.b.c");
            Assert.IsTrue("a.b.c.d.e".DotFirst(10)== "a.b.c.d.e");
            Assert.IsTrue("".DotFirst()== "");
            Assert.IsTrue("a".DotFirst()== "a");

            Assert.IsTrue("a.b.c.d.e".DotLast()== "e");
            Assert.IsTrue("a.b.c.d.e".DotLast(2)== "d.e");
            Assert.IsTrue("a.b.c.d.e".DotLast(3)== "c.d.e");
            Assert.IsTrue("a.b.c.d.e".DotLast(10)== "a.b.c.d.e");
            Assert.IsTrue("".DotLast()== "");
            Assert.IsTrue("a".DotLast()== "a");
        }

        [Test()]
        public void TestString3()
        {
            Assert.IsTrue("Key=Value".KeyFromKVPair() == "Key");
            Assert.IsTrue("Key=Value".ValueFromKVPair() == "Value");

            Assert.IsTrue("Key=Value=Hallo".KeyFromKVPair() == "");
            Assert.IsTrue("".KeyFromKVPair() == "");
            Assert.IsTrue("Key".KeyFromKVPair() == "");

            Assert.IsTrue("Key=Value=Hallo".ValueFromKVPair() == "");
            Assert.IsTrue("".ValueFromKVPair() == "");
            Assert.IsTrue("Key".ValueFromKVPair() == "");
        }

        [Test()]
        public void TestString4()
        {
            Assert.IsTrue("First:Last".Before(":")=="First");
            Assert.IsTrue("First:Last".LastBefore(":") == "First");
            Assert.IsTrue("First:Last".After(":") == "Last");
            Assert.IsTrue("First:Last".LastAfter(":") == "Last");

            Assert.IsTrue("First:G2:G3:Last".Before(":") == "First");
            Assert.IsTrue("First:G2:G3:Last".LastBefore(":") == "First:G2:G3");
            Assert.IsTrue("First:G2:G3:Last".After(":") == "G2:G3:Last");
            Assert.IsTrue("First:G2:G3:Last".LastAfter(":") == "Last");

            Assert.IsTrue("First:G2:G2:G2:Last".Before("G2") == "First:");
            Assert.IsTrue("First:G2:G2:G2:Last".LastBefore("G2") == "First:G2:G2:");
            Assert.IsTrue("First:G2:G2:G2:Last".After("G2") == ":G2:G2:Last");
            Assert.IsTrue("First:G2:G2:G2:Last".LastAfter("G2") == ":Last");
        }
    }
}

