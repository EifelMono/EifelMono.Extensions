using System;
using EifelMono.Extensions;
using System.Collections.Generic;

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
            Select select = new Select()
                .Options(useBase64: true, useEncrypt: false, useCompress: false)
                .OnOutput((t, o, s) =>
                {
                    Console.WriteLine($"OutputAsText={t} Output.type= {o.GetType()}");
                    if (s.UseBase64)
                        Console.WriteLine($"Output={s.FromBase64(t)}");
                })
                .Case<MessageA>((o, s) =>
                {
                    Console.WriteLine($"MessageA.A={o.A}");
                })
                .Case<MessageB>((o, s) =>
                {
                    Console.WriteLine($"MessageB.B={o.B}");
                    s.Output(new MessageA { A = o.B });
                })
                .Case<MessageAB>((o, s) =>
                {
                    Console.WriteLine($"MessageAB.A={o.A}");
                    Console.WriteLine($"MessageAB.B={o.B}");
                })
                .Default((o, s) =>
                {
                Console.WriteLine($"Default:{o}");
                });

            List<object> Messages = new List<object>
            {
                new MessageA { A = "MessageA.A" },
                new MessageB { B = "MessageB.B" },
                new MessageAB { A = "MessageAB.A", B = "MessageAB.B" },
                "Hallo"
            };

            // Test as obj
            foreach (var message in Messages)
                select.Input(message);

            // Test as obj no base64 input/output
            select.UseBase64 = false;
            foreach (var testMessage in Messages)
                select.Input(select.ToText(testMessage));

            // Test as obj base64 input/output
            select.UseBase64 = true;
            foreach (var testMessage in Messages)
                select.Input(select.ToText(testMessage));
        }
    }
}
