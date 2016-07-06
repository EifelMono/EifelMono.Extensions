using System;
using NUnit.Framework;
using System.ComponentModel;

namespace EifelMono.Extensions.Test
{
    public class MessageA : SwitchMessage
    {
        public string A { get; set; }
    }

    public class MessageB : SwitchMessage
    {
        public string B { get; set; }
    }

    public class MessageAB : MessageA
    {
        public string B { get; set; }
    }


    [TestFixture()]
    public class TestMessage
    {
        MessageSwitch TestSwitch = new MessageSwitch();
        string ResultOnOutput = "";
        string ResultOnCaseMessageA = "";
        string ResultOnCaseMessageB = "";

        public TestMessage()
        {
            TestSwitch.OnOutput = (text) =>
            {

            };

            TestSwitch.Case<MessageA>((obj) =>
            {
                ResultOnCaseMessageA = obj.A;
            });

            TestSwitch.Case<MessageB>((obj) =>
            {
                ResultOnCaseMessageB = obj.B;
            });

            TestSwitch.Case<MessageAB>((obj) =>
            {
                ResultOnCaseMessageA = obj.A;
                ResultOnCaseMessageB = obj.B;
            });


        }
        [Test()]
        public void Test1()
        {
            TestSwitch.Switch(new MessageA
            {
                A = "Hello",
            }, true);
            Assert.IsTrue(ResultOnCaseMessageA == "Hello");

            TestSwitch.Switch(new MessageB
            {
                B = "World",
            }, true);
            Assert.IsTrue(ResultOnCaseMessageB == "World");

            TestSwitch.Switch(new MessageAB
            {
                A = "A",
                B = "B"
            }, true);
            Assert.IsTrue(ResultOnCaseMessageA == "A" && ResultOnCaseMessageB == "B");
        }
    }
}

