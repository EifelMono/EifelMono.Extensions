using NUnit.Framework;
using static EifelMono.Extensions.Static;

namespace EifelMono.Extensions.Test
{
    public class TestGeneric
    {
        [Test()]
        public void Test1()
        {
            int count = 1;
            foreach(var x in ValuesAsEnumerable("1", "2", "3"))
            {
                Assert.IsTrue(count.ToString()== x);
                count++;
            }
            count = 1;
            foreach (var x in ValuesAsList("1", "2", "3"))
            {
                Assert.IsTrue(count.ToString() == x);
                count++;
            }
            count = 1;
            foreach (var x in ValuesAsArray("1", "2", "3"))
            {
                Assert.IsTrue(count.ToString() == x);
                count++;
            }
        }
        [Test()]
        public void Test2()
        {
            int count = 1;
            foreach (var x in ValuesAsEnumerable(1, 2, 3))
            {
                Assert.IsTrue(count == x);
                count++;
            }
            count = 1;
            foreach (var x in ValuesAsList(1, 2, 3))
            {
                Assert.IsTrue(count == x);
                count++;
            }
            count = 1;
            foreach (var x in ValuesAsArray(1, 2, 3))
            {
                Assert.IsTrue(count == x);
                count++;
            }
        }
    }
}

