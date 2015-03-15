using NUnit.Framework;
using System;
using System.Collections.Generic;
using EifelMono.Extensions;
using System.Diagnostics;

namespace EifelMono.Extensions.Test
{
    [TestFixture()]
    public class TestClass
    {

    

        public class ClassA
        {
            
        }


        public class ClassB: ClassA
        {
            
        }


        public class ClassC: ClassB
        {
            
        }


        [Test()]
        public void TestClass1()
        {
            var TestValues = new object[] { new ClassA(), new ClassB(), new ClassC() };
            var TestResults = new int[] { 0, 1, 2 };

            for (int index = 0; index < TestValues.Length; index++)
            {
                var result = -1;
                TestValues[index].Switch()
                    .CaseType(typeof(ClassA), (p) =>
                    {
                        result = 0;
                    })
                    .CaseType(typeof(ClassB), (p) =>
                    {
                        result = 1;
                    })
                    .CaseType(typeof(ClassC), (p) =>
                    {
                        result = 2;
                    });
                Assert.IsTrue(TestResults[index] == result);
            }
        }

        [Test()]
        public void TestClass2()
        {
            new ClassA().Switch()
                .CaseIs(typeof(ClassA), (p) =>
                {
                    Assert.IsTrue(true);
                })
                .CaseIs(typeof(ClassB), (p) =>
                {
                    Assert.Fail();
                })
                .CaseIs(typeof(ClassC), (p) =>
                {
                    Assert.Fail();
                })
                .Default((p) =>
                {
                    Assert.Fail();
                               
                });
            
            new ClassB().Switch()
                .CaseIs(typeof(ClassA))
                .And()
                .CaseIs(typeof(ClassB), (p) =>
                {
                    Assert.IsTrue(true);
                })
                .CaseIs(typeof(ClassC), (p) =>
                {
                    Assert.Fail();
                })
                .Default((p) =>
                {
                    Assert.Fail();

                });
            
            new ClassC().Switch()
                .CaseIs(typeof(ClassA))
                .And()
                .CaseIs(typeof(ClassB))
                .CaseIs(typeof(ClassC), (p) =>
                {
                    Assert.IsTrue(true);
                })
                .Default((p) =>
                {
                    Assert.Fail();

                });
        }
    }
}

