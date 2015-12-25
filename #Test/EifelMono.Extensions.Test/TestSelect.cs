using NUnit.Framework;
using System;
using System.Collections.Generic;
using EifelMono.Extensions;
using System.Diagnostics;

namespace EifelMono.Extensions.Test
{
    [TestFixture()]
    public class TestSelect
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
                .CaseOn < Action<int>>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("< Action<int>>");
                    p.Continue();
                })
                .CaseOn<ClassA>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("o.A={0}", o.A);
                    p.Continue();
                })
                .CaseOn<ClassB>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("o.A={0}", o.A);
                    Debug.WriteLine("o.B={0}", o.B);
                    p.Continue();
                })
                .CaseOn<ClassC>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("o.A={0}", o.A);
                    Debug.WriteLine("o.B={0}", o.B);
                    Debug.WriteLine("o.C={0}", o.C);
                    p.Continue();
                })
                .CaseOn<string>((o) =>
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
                .CaseOn<ClassA>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("o.A={0}", o.A);
                    p.Continue();
                })
                .CaseOn<string>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("o={0}", o);
                    p.Continue();
                })
                .CaseOn<int>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("o={0}", o);
                    p.Continue();
                })
                .CaseOn<double>((o) =>
                {
                    return true;
                }, (p, o) =>
                {
                    Debug.WriteLine("o={0}", o);
                    p.Continue();
                })
                .CaseOn<bool>((o) =>
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
                .CaseOn<ClassA>((p, o) =>
                    {
                        Debug.WriteLine("o.A={0}", o.A);
                        p.Continue();
                    })
                .CaseOn<string>((p, o) =>
                    {
                        Debug.WriteLine("o={0}", o);
                        p.Continue();
                    })
                .CaseOn<int>((p, o) =>
                    {
                        Debug.WriteLine("o={0}", o);
                        p.Continue();
                    })
                .CaseOn<double>((p, o) =>
                    {
                        Debug.WriteLine("o={0}", o);
                        p.Continue();
                    })
                .CaseOn<bool>((p, o) =>
                    {
                        Debug.WriteLine("o={0}", o);
                        p.Continue();
                    })
                .Default((p) =>
                    {
                        Debug.WriteLine("Default");
                    });
        }

    }
}

