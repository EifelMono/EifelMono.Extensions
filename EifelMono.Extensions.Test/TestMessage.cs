using System;
using NUnit.Framework;
using System.ComponentModel;

namespace EifelMono.Extensions.Test
{
    public class MessageA : Message
    {
        public string A { get; set; }
    }

    public class MessageB : Message
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
        MessageConverter BaseConverter = new MessageConverter();
        string ResultOnOutput = "";
        string ResultOnInputMessageA = "";
        string ResultOnInputMessageB = "";

        public TestMessage()
        {
            BaseConverter.OnOutput = (text) =>
            {

            };

            BaseConverter.OnInput<MessageA>((obj) =>
            {
                ResultOnInputMessageA = obj.A;
            });

            BaseConverter.OnInput<MessageB>((obj) =>
            {
                ResultOnInputMessageB = obj.B;
            });

            BaseConverter.OnInput<MessageAB>((obj) =>
            {
                ResultOnInputMessageA = obj.A;
                ResultOnInputMessageB = obj.B;
            });


        }
        [Test()]
        public void Test1()
        {
            BaseConverter.Input(new MessageA
            {
                A = "Hello",
            }, true);
            Assert.IsTrue(ResultOnInputMessageA == "Hello");

            BaseConverter.Input(new MessageB
            {
                B = "World",
            }, true);
            Assert.IsTrue(ResultOnInputMessageB == "World");

            BaseConverter.Input(new MessageAB
            {
                A = "A",
                B = "B"
            }, true);
            Assert.IsTrue(ResultOnInputMessageA == "A" && ResultOnInputMessageB == "B");
        }
    }
}

