using System;
using NUnit.Framework;
using EifelMono.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace EifelMono.Extensions.Test
{
    [TestFixture()]
    public class TestPipe
    {
        List<string> list1 = new List<string>
                {
                 "list1.1",
                 "list1.2"
                }
                .Pipe(p => p.Add("list1.3"))
                .Pipe(p => p.RemoveAt(0));

        [Test()]
        public void Test1()
        {
            Assert.IsTrue(list1.Count == 2);
            Assert.IsTrue(list1.Contains("list1.1") == false);
            Assert.IsTrue(list1[0] == "list1.2");
            Assert.IsTrue(list1[1] == "list1.3");
        }

        List<string> list2 = new List<string>
                {
                 "Hello World",
                }
                .Pipe((p) =>
                {
                    for (var i = 0; i < 10; i++)
                        p.Add($"list2.{i} {DateTime.Now}");
                });

        [Test()]
        public void Test2()
        {
            Assert.IsTrue(list2.Count == 11);
            Assert.IsTrue(list2.Contains("Hello World"));
            Assert.IsTrue(list2.InContains("Hello World"));
            Assert.IsTrue(list2.Where(l => l.StartsWith("list2.")).Count() == 10);
        }


        [Test()]
        public void Test3()
        {
            List<string> list3 = new List<string>
                {
                 "list3.1",
                 "list3.2",
                }
                .Pipe(p => p.AddRange(list1));

            Assert.IsTrue(list3.Count == 4);
            Assert.IsTrue(list3.Contains("Line1") == false);
            Assert.IsTrue(list3[0] == "list3.1");
            Assert.IsTrue(list3[1] == "list3.2");
            Assert.IsTrue(list3[2] == "list1.2");
            Assert.IsTrue(list3[3] == "list1.3");
        }

        [Test()]
        public void Test4()
        {
            string a = "Hallo".Pipe((v) =>
            {
                 v = v + "Karl";
            });
            Assert.IsTrue(a == "Hallo");

            string b = "Hallo".Pipe((v) =>
            {
                v = v + "Karl";
                return v;
            });
            Assert.IsTrue(b == "HalloKarl");

            int x = 4.Pipe((v) =>
            {
                v = v + 1;
            });
            Assert.IsTrue(x == 4);

            int y = 4.Pipe((v) =>
            {
                v = v + 1;
                return v;
            });
            Assert.IsTrue(y == 5);
        }
    }
}

