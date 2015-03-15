using NUnit.Framework;
using System;

namespace EifelMono.Extensions.Test
{
    [TestFixture()]
    public class TestSwitch
    {
        [Test()]
        public void TestSwitch1()
        {
            var TestValues = new int[] { 1, 2, 3, 4, 5, 6 };
            var TestResults = new int[] { 1, 2, 2, 3, 3, 3 };
            for (int index = 0; index < TestValues.Length; index++)
            {
                int result = -1;
                TestValues[index].Switch()
                    .Case(1, (p) =>
                    {
                        result = 1;
                    })
                    .CaseIn(2, 3, (p) =>
                    {
                        result = 2;
                    })
                    .CaseInRange(4, 6, (p) =>
                    {
                        result = 3;
                    });
                Assert.IsTrue(TestResults[index] == result);
            }
        }

        [Test()]
        public void TestSwitch2()
        {
            for (int i = -1; i < 3; i++)
            {
                int result = -100;
                i.Switch()
                    .Case(-1, (p) =>
                    {
                        result = -1;
                    })
                    .Case(0, (p) =>
                    {
                        result = 0;
                    })
                    .Case(1, (p) =>
                    {
                        result = 1;
                    })
                    .Default((p) =>
                    {
                        result = 2;
                    });
                Assert.AreEqual(i, result);
            }
          
        }
    }
}

