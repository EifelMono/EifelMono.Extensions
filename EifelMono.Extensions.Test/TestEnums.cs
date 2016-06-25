using System.Linq;
using NUnit.Framework;
using static EifelMono.Extensions.Static;

namespace EifelMono.Extensions.Test
{
    [TestFixture()]
    public class TestEnum
    {
        public enum TestSet
        {
            Enum1,
            EnUm2,
            Enum3
        }

        [Test()]
        public void TestEnum1()
        {
            var a = TestSet.Enum1.EnumerateAllValues();
            Assert.IsTrue(a.ToList().Count == 3);
            {
                int count = 0;
                foreach (var x in TestSet.Enum1.EnumerateAllValues())
                {
                    if (x == TestSet.Enum1)
                        count += 1;
                    if (x == TestSet.EnUm2)
                        count += 10;
                    if (x == TestSet.Enum3)
                        count += 100;
                }
                Assert.IsTrue(count == 111);
            }

            {
                
                int count = 0;
                foreach (var x in TestSet.Enum1.EnumerateAllValuesAsInt())
                {
                    if (x == (int)TestSet.Enum1)
                        count += 1;
                    if (x == (int)TestSet.EnUm2)
                        count += 10;
                    if (x == (int)TestSet.Enum3)
                        count += 100;
                }
                Assert.IsTrue(count == 111);
            }

            {
                int count = 0;
                foreach (var x in TestSet.Enum1.EnumerateAllNames())
                {
                    if (x == TestSet.Enum1.ToString())
                        count += 1;
                    if (x == TestSet.EnUm2.ToString())
                        count += 10;
                    if (x == TestSet.Enum3.ToString())
                        count += 100;
                }
                Assert.IsTrue(count == 111);
            }
        }

        [Test()]
        public void TestEnum1Static()
        {
            var a = Enumerate<TestSet>();
            Assert.IsTrue(a.ToList().Count == 3);
            int count = 0;
            foreach (var x in Enumerate<TestSet>())
            {
                if (x == TestSet.Enum1)
                    count += 1;
                if (x == TestSet.EnUm2)
                    count += 10;
                if (x == TestSet.Enum3)
                    count += 100;
            }
            Assert.IsTrue(count == 111);
        }
    }
}

