using System;
using System.Diagnostics;
using NUnit.Framework;

namespace EifelMono.Extensions.Test
{
    [TestFixture()]
    public class TestExtensionSelect
    {
        public class ClassA
        {
            public string A { get; set; }= "A";
        }


        public class ClassB: ClassA
        {
            public string B { get; set; }= "B";
        }


        public class ClassC: ClassB
        {
            public string C { get; set; }= "C";
        }

        [Test()]
        public void TestObject1()
        {
            ClassB TestValue = new ClassB();


            if (TestValue is ClassA)
                Debug.WriteLine("ClassA");
            if (TestValue is ClassB)
                Debug.WriteLine("ClassB");
            if (TestValue is ClassC)
                Debug.WriteLine("ClassC");

            TestValue.Select()
                .CaseAs < Action<int>>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("< Action<int>>");
                    p.Continue();
                })
                .CaseAs<ClassA>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("o.A={0}", o.A);
                    p.Continue();
                })
                .CaseAs<ClassB>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("o.A={0}", o.A);
                    Debug.WriteLine("o.B={0}", o.B);
                    p.Continue();
                })
                .CaseAs<ClassC>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("o.A={0}", o.A);
                    Debug.WriteLine("o.B={0}", o.B);
                    Debug.WriteLine("o.C={0}", o.C);
                    p.Continue();
                })
                .CaseAs<string>((o) =>
                {
                    return true; 
                },
                (p, o) =>
                {
                    p.Continue();
                })
                .Default((p) =>
                {
                    Debug.WriteLine("Default");
                });
        }


        [Test()]
        public void TestObject2()
        {
            bool TestValue = true;

            TestValue.Select()
                .CaseAs<ClassA>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("o.A={0}", o.A);
                    p.Continue();
                })
                .CaseAs<string>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("o={0}", o);
                    p.Continue();
                })
                .CaseAs<int>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("o={0}", o);
                    p.Continue();
                })
                .CaseAs<double>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("o={0}", o);
                    p.Continue();
                })
                .CaseAs<bool>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("o={0}", o);
                    p.Continue();
                })
                .Default((p) =>
                {
                    Debug.WriteLine("Default");
                });
        }

        [Test()]
        public void TestObject3()
        {
            bool TestValue = true;

            TestValue.Select()
                .CaseAs<ClassA>((p, o) =>
                {
                    Debug.WriteLine("o.A={0}", o.A);
                    p.Continue();
                })
                .CaseAs<string>((p, o) =>
                {
                    Debug.WriteLine("o={0}", o);
                    p.Continue();
                })
                .CaseAs<int>((p, o) =>
                {
                    Debug.WriteLine("o={0}", o);
                    p.Continue();
                })
                .CaseAs<double>((p, o) =>
                {
                    Debug.WriteLine("o={0}", o);
                    p.Continue();
                })
                .CaseAs<bool>((p, o) =>
                {
                    Debug.WriteLine("o={0}", o);
                    p.Continue();
                })
                .Default((p) =>
                {
                    Debug.WriteLine("Default");
                });
        }

        [Test()]
        public void TestObject4()
        {
            var TestValue = new ClassC();

            if (TestValue is ClassA)
                Debug.WriteLine("ClassA");
            if (TestValue is ClassB)
                Debug.WriteLine("ClassB");
            if (TestValue is ClassC)
                Debug.WriteLine("ClassC");

            int count = 0;

            TestValue.Select()
                .CaseAs<ClassA>(
                (p, o) =>
                {
                    Debug.WriteLine("o.A={0}", o.A);
                    p.Continue();
                    count += 1;
                })
                .CaseAs<ClassB>(
                (p, o) =>
                {
                    Debug.WriteLine("o.A={0}", o.A);
                    Debug.WriteLine("o.B={0}", o.B);
                    p.Continue();
                    count += 10;
                })
                .CaseAs<ClassC>((p, o) =>
                {
                    Debug.WriteLine("o.A={0}", o.A);
                    Debug.WriteLine("o.B={0}", o.B);
                    Debug.WriteLine("o.C={0}", o.C);
                    count += 100;
                })
                .Default((p) =>
                {
                    Debug.WriteLine("Default");
                    count += 1000;
                });
            Assert.IsTrue(count == 111);
        }

        [Test()]
        public void TestObject5()
        {
            var TestValue = new ClassC();

            if (TestValue is ClassA)
                Debug.WriteLine("ClassA");
            if (TestValue is ClassB)
                Debug.WriteLine("ClassB");
            if (TestValue is ClassC)
                Debug.WriteLine("ClassC");

            int count = 0;

            TestValue.Select()
                .Case<ClassA>(
                (p, o) =>
                {
                    Debug.WriteLine("o.A={0}", o.A);
                    count += 1;
                })
                .Case<ClassB>(
                (p, o) =>
                {
                    Debug.WriteLine("o.A={0}", o.A);
                    Debug.WriteLine("o.B={0}", o.B);
                    count += 10;
                })
                .Case<ClassC>((p, o) =>
                {
                    Debug.WriteLine("o.A={0}", o.A);
                    Debug.WriteLine("o.B={0}", o.B);
                    Debug.WriteLine("o.C={0}", o.C);
                    count += 100;
                })
                .Default((p) =>
                {
                    Debug.WriteLine("Default");
                    count += 1000;
                });
            Assert.IsTrue(count == 100);
        }

    }
}

