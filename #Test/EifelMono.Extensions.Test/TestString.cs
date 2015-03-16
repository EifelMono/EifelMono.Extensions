using NUnit.Framework;
using System;
using System.Collections.Generic;
using EifelMono.Extensions;

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
    }
}

