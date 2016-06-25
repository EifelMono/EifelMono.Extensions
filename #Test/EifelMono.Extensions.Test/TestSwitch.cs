using NUnit.Framework;

namespace EifelMono.Extensions.Test
{
    //[TestFixture()]
    //public class TestSwitch
    //{
    //    [Test()]
    //    public void TestSwitchForMd1()
    //    {
    //        int TestValue = 1;
    //        int result = -1;
    //        TestValue.Switch()
    //            .Case(2, (p) =>
    //            {
    //                result = 0;
    //            })
    //            .CaseIn(3, 4, 5, (p) =>
    //            {
    //                result = 1;
    //            })
    //            .CaseInRange(10, 20, (p) =>
    //            {
    //                result = 2;
    //            })
    //            .Default((p) =>
    //            {
    //                result = 10;
    //            });
    //        Assert.IsTrue(result == 10);
    //    }

    //    [Test()]
    //    public void TestSwitchForMd2()
    //    {
    //        int TestValue = 1;
    //        int result = -1;
    //        TestValue.Switch()
    //            .Case(1, (p) =>
    //            {
    //                result++;
    //                p.Continue();
    //            })
    //            .CaseIn(1, 2, 3, 4, (p) =>
    //            {
    //                result++;
    //                p.Continue();
    //            })
    //            .CaseInRange(1, 10, (p) =>
    //            {
    //                result++;
    //            })
    //            .Default((p) =>
    //            {
    //                result += 10;
    //            });
    //        Assert.IsTrue(result == 2);
    //    }

    //    [Test()]
    //    public void TestSwitchForMd3()
    //    {
    //        string TestValue = "Hugo";
    //        int result = -1;
    //        TestValue.Switch()
    //            .Case("Bob", (p) =>
    //            {
    //                result = 0;
    //            })
    //            .CaseIn("Ben", "Leo", (p) =>
    //            {
    //                result = 1;
    //            })
    //            .CaseStartsWith("Hu")
    //            .And()
    //            .CaseEndsWith("O", (p) =>
    //            {
    //                result = 2;
    //            })
    //            .CaseStartsWith("Hug")
    //            .And()
    //            .CaseEndsWith("o", (p) =>
    //            {
    //                result = 3;
    //            })
    //            .Default((p) =>
    //            {
    //                result += 10;
    //            });
    //        Assert.IsTrue(result == 3);
    //    }


    //    [Test()]
    //    public void TestSwitch1()
    //    {
    //        var TestValues = new int[] { 1, 2, 3, 4, 5, 6 };
    //        var TestResults = new int[] { 1, 2, 2, 3, 3, 3 };
    //        for (int index = 0; index < TestValues.Length; index++)
    //        {
    //            int result = -1;
    //            TestValues[index].Switch()
    //                .Case(1, (p) =>
    //                {
    //                    result = 1;
    //                })
    //                .CaseIn(2, 3, (p) =>
    //                {
    //                    result = 2;
    //                })
    //                .CaseInRange(4, 6, (p) =>
    //                {
    //                    result = 3;
    //                });
    //            Assert.IsTrue(TestResults[index] == result);
    //        }
    //    }

    //    [Test()]
    //    public void TestSwitch2()
    //    {
    //        for (int i = -1; i < 3; i++)
    //        {
    //            int result = -100;
    //            i.Switch()
    //                .Case(-1, (p) =>
    //                {
    //                    result = -1;
    //                })
    //                .Case(0, (p) =>
    //                {
    //                    result = 0;
    //                })
    //                .Case(1, (p) =>
    //                {
    //                    result = 1;
    //                })
    //                .Default((p) =>
    //                {
    //                    result = 2;
    //                });
    //            Assert.AreEqual(i, result);
    //        }
          
    //    }

    //    [Test()]
    //    public void TestSwitch3()
    //    {
    //        int TestValue = 1;
    //        int result = -1;
    //        TestValue.Switch()
    //            .Case(1, (p) =>
    //            {
    //                result++;
    //            })
    //                .Case(2, (p) =>
    //            {
    //                result++;
    //            })
    //                .Case(3, (p) =>
    //            {
    //                result++;
    //            })
    //                .Default((p) =>
    //            {
    //                result++;
    //            });
    //        Assert.IsTrue(result == 0);

    //        result = -1;
    //        TestValue.Switch()
    //            .Case(1, (p) =>
    //            {
    //                result++;
    //                p.Continue();
    //            })
    //            .CaseIn(1, 2, 3, (p) =>
    //            {
    //                result++;
    //                p.Continue();
    //            })
    //            .CaseOut(3, (p) =>
    //            {
    //                result++;
    //            })
    //            .Default((p) =>
    //            {
    //                result++;
    //            });
    //        Assert.IsTrue(result == 2);

    //        result = -1;
    //        TestValue.Switch()
    //            .Case(1, (p) =>
    //            {
    //                result++;
    //                p.Continue();
    //            })
    //            .CaseIn(1, 2, 3, (p) =>
    //            {
    //                result++;
    //                p.Continue();
    //            })
    //            .CaseOut(3, (p) =>
    //            {
    //                result++;
    //                p.Continue();
    //            })
    //            .Default((p) =>
    //            {
    //                result++;
    //            });
    //        Assert.IsTrue(result == 3);
    //    }

    //    [Test()]
    //    public void TestSwitch4()
    //    {
    //        int TestValue = 1;
    //        int result = -1;
    //        TestValue.Switch()
    //            .Case(-1, (p) =>
    //            {
    //                result = -1;
    //            })
    //            .Case(1)
    //            .AndPush()
    //            .CaseIn(1, 2)
    //            .CaseInRange(5, 10, (p) =>
    //            {
    //                result = 0;
    //            })
    //            .Default((p) =>
    //            {
    //                result = 1;
    //            });
    //        Assert.IsTrue(result== 0);

    //        result = -1;
    //        TestValue.Switch()
    //            .Case(-1, (p) =>
    //                {
    //                    result = -1;
    //                })
    //            .Case(2)
    //            .AndPush()
    //            .CaseIn(1, 2)
    //            .CaseInRange(5, 10, (p) =>
    //                {
    //                    result = 0;
    //                })
    //            .Default((p) =>
    //                {
    //                    result = 1;
    //                });
    //        Assert.IsTrue(result== 1);

    //        result = -1;
    //        TestValue.Switch()
    //            .Case(-1, (p) =>
    //                {
    //                    result = -1;
    //                })
    //            .Case(2)
    //            .CaseIn(1, 2)
    //            .CaseInRange(5, 10, (p) =>
    //                {
    //                    result = 0;
    //                })
    //            .Default((p) =>
    //                {
    //                    result = 1;
    //                });
    //        Assert.IsTrue(result== 0);

    //    }
    //}
}
