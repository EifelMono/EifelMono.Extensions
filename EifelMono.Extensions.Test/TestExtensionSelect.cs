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
                .Case < Action<int>>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("< Action<int>>");
                    p.Continue();
                })
                .Case<ClassA>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("o.A={0}", o.A);
                    p.Continue();
                })
                .Case<ClassB>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("o.A={0}", o.A);
                    Debug.WriteLine("o.B={0}", o.B);
                    p.Continue();
                })
                .Case<ClassC>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("o.A={0}", o.A);
                    Debug.WriteLine("o.B={0}", o.B);
                    Debug.WriteLine("o.C={0}", o.C);
                    p.Continue();
                })
                .Case<string>((o) =>
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
                .Case<ClassA>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("o.A={0}", o.A);
                    p.Continue();
                })
                .Case<string>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("o={0}", o);
                    p.Continue();
                })
                .Case<int>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("o={0}", o);
                    p.Continue();
                })
                .Case<double>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("o={0}", o);
                    p.Continue();
                })
                .Case<bool>((o) =>
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
                .Case<ClassA>((p, o) =>
                {
                    Debug.WriteLine("o.A={0}", o.A);
                    p.Continue();
                })
                .Case<string>((p, o) =>
                {
                    Debug.WriteLine("o={0}", o);
                    p.Continue();
                })
                .Case<int>((p, o) =>
                {
                    Debug.WriteLine("o={0}", o);
                    p.Continue();
                })
                .Case<double>((p, o) =>
                {
                    Debug.WriteLine("o={0}", o);
                    p.Continue();
                })
                .Case<bool>((p, o) =>
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
                .Case<ClassA>(
                (p, o) =>
                {
                    Debug.WriteLine("o.A={0}", o.A);
                    p.Continue();
                    count += 1;
                })
                .Case<ClassB>(
                (p, o) =>
                {
                    Debug.WriteLine("o.A={0}", o.A);
                    Debug.WriteLine("o.B={0}", o.B);
                    p.Continue();
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
                .CaseOnEqual<ClassA>(
                (p, o) =>
                {
                    Debug.WriteLine("o.A={0}", o.A);
                    count += 1;
                })
                .CaseOnEqual<ClassB>(
                (p, o) =>
                {
                    Debug.WriteLine("o.A={0}", o.A);
                    Debug.WriteLine("o.B={0}", o.B);
                    count += 10;
                })
                .CaseOnEqual<ClassC>((p, o) =>
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

