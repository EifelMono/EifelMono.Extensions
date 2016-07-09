using System;
using EifelMono.Extensions;

namespace SelectSample
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

    class MainClass
    {
        public static void Main(string[] args)
        {
            string ResultOnCaseMessageA = "";
            string ResultOnCaseMessageB = "";
            Select select = new Select();

            select.Options(useBase64: true, useEncrypt: false, useCompress: false)
            .OnOutput((text) =>
            {
                Console.WriteLine($"Output={text}");
                if (select.UseBase64)
                    Console.WriteLine($"Output={select.FromBase64(text)}");
            })
            .Case<MessageA>((obj, s) =>
            {
                ResultOnCaseMessageA = obj.A;
            })
            .Case<MessageB>((obj, s) =>
            {
                ResultOnCaseMessageB = obj.B;
                s.Output(new MessageA { A = obj.B });
            })
            .Case<MessageAB>((obj, s) =>
            {
                ResultOnCaseMessageA = obj.A;
                ResultOnCaseMessageB = obj.B;
            });

            select.InputUnitTest(new MessageA { A = "MessageA.A" });
            Console.WriteLine($"MessageA.A={ResultOnCaseMessageA}");
            select.InputUnitTest(new MessageB { B = "MessageB.B" });
            Console.WriteLine($"MessageB.B={ResultOnCaseMessageB}");
            select.InputUnitTest(new MessageAB { A = "MessageAB.A", B = "MessageAB.B" });
            Console.WriteLine($"MessageAB.A={ResultOnCaseMessageA} MessageAB.B={ResultOnCaseMessageB}");

            select.UseBase64 = false;
            select.InputUnitTest(new MessageA { A = "MessageA.A" });
            Console.WriteLine($"MessageA.A={ResultOnCaseMessageA}");
            select.InputUnitTest(new MessageB { B = "MessageB.B" });
            Console.WriteLine($"MessageB.B={ResultOnCaseMessageB}");
            select.InputUnitTest(new MessageAB { A = "MessageAB.A", B = "MessageAB.B" });
            Console.WriteLine($"MessageAB.A={ResultOnCaseMessageA} MessageAB.B={ResultOnCaseMessageB}");
        }
    }
}
