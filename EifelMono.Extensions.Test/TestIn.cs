using System.Collections.Generic;
using NUnit.Framework;

namespace EifelMono.Extensions.Test
{
    [TestFixture()]
    public class TestIn
    {
        public enum TestEnum
        {
            Karl,
            Heinz,
            Werner,
            Egon
        }

        [Test()]
        public void TestIn1()
        {
            int x = 5;
            Assert.IsTrue(x.In(1, 2, 3, 4, 5));
            Assert.IsTrue(x.In(5, 1, 2, 3, 4));
            Assert.IsTrue(x.In(5, 5, 5, 5));
            Assert.IsFalse(x.In(1, 2, 3, 4));

            TestEnum name = TestEnum.Karl;
            Assert.IsTrue(name.In(TestEnum.Egon, TestEnum.Werner, TestEnum.Karl));
            Assert.IsFalse(name.In(TestEnum.Egon, TestEnum.Werner));
        }

        [Test()]
        public void TestIn2()
        {
            int[] intArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int x = 5;
            Assert.IsTrue(x.In(intArray));
            Assert.IsTrue(x.In(intList));
            intList.Remove(5);
            Assert.IsFalse(x.In(intList));
        }
    }
}

