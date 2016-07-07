using System;
using NUnit.Framework;
using System.ComponentModel;
using System.Diagnostics;

namespace EifelMono.Extensions.Test
{
    public class MessageA
    {
        public string A { get; set; }
    }

    public class MessageB
    {
        public string B { get; set; }
    }

    public class MessageAB : MessageA
    {
        public string B { get; set; }
    }


    [TestFixture()]
    public class TestSelect1
    {
        Select select = new Select();
        string ResultOnCaseMessageA = "";
        string ResultOnCaseMessageB = "";

        public TestSelect1()
        {
            select.OnOutput((text) =>
            {

            });

            select.Case<MessageA>((obj, s) =>
            {
                ResultOnCaseMessageA = obj.A;
            });

            select.Case<MessageB>((obj, s) =>
            {
                ResultOnCaseMessageB = obj.B;
            });

            select.Case<MessageAB>((obj, s) =>
            {
                ResultOnCaseMessageA = obj.A;
                ResultOnCaseMessageB = obj.B;
            });


        }
        [Test()]
        public void Test1()
        {
            select.InputUnitTest(new MessageA
            {
                A = "Hello",
            });
            Assert.IsTrue(ResultOnCaseMessageA == "Hello");

            select.InputUnitTest(new MessageB
            {
                B = "World",
            });
            Assert.IsTrue(ResultOnCaseMessageB == "World");

            select.InputUnitTest(new MessageAB
            {
                A = "A",
                B = "B"
            });
            Assert.IsTrue(ResultOnCaseMessageA == "A" && ResultOnCaseMessageB == "B");
        }
    }

    [TestFixture()]
    public class TestSelect2
    {
        [Test()]
        public void Test21()
        {
            string ResultOnCaseMessageA = "";
            string ResultOnCaseMessageB = "";
            Select select = new Select()
            .OnOutput((text) =>
            {

            })
            .Case<MessageA>((a, s) =>
            {
                ResultOnCaseMessageA = a.A;
                s.Output(null);
            })
            .Case<MessageB>((b, s) =>
            {
                ResultOnCaseMessageB = b.B;
            })
            .Case<MessageAB>((ab, s) =>
            {
                ResultOnCaseMessageA = ab.A;
                ResultOnCaseMessageB = ab.B;
            })
            .Default((obj, s) =>
            {

            });
        }
    }

}

