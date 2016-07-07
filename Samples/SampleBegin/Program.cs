using System;
using EifelMono.Extensions;

namespace SampleBegin
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Log.Proxy = new LogProxyConsole();

            #region In
            InInt();
            InString();
            #endregion

            #region Switch
            SwitchInt();
            SwitchString();
            #endregion

            #region Other
            LogAll();
            TestSelect();
            #endregion

            Console.WriteLine("Ready");
            Console.ReadLine();
        }

        #region In

        public static void InInt()
        {
            int Test = 2;
            if (Test.In(1, 2, 3, 4))
            {
                Console.WriteLine("In(1,2,3,4");
            }
            if (Test.InRange(2, 10))
            {
                Console.WriteLine("InRange(2,10");
            }
            Console.WriteLine("InInt Test={0}", Test);
        }

        public static void InString()
        {
            string Test = "Karl";
            if (Test.In("Hugo", "Karl", "Werner"))
            {
                Console.WriteLine("In(Hugo, Karl, Werner");
            }
            Console.WriteLine("InString Test={0}", Test);
        }

        #endregion

        #region Switch

        public static void SwitchInt()
        {
            int Test = 1;

            Test.Switch()
                .Case(2, (r) =>
                {
                    Console.WriteLine("Case(2, ");
                })
                .CaseIn(3, 4, 5, (r) =>
                {
                    Console.WriteLine("CaseIn(3, 4, 5,");
                })
                .CaseInRange(10, 20, (r) =>
                {
                    Console.WriteLine("CaseInRange(19, 20,");
                })
                .CaseTrue(DateTime.Now.Second == 4711, (r) =>
                {
                    Console.WriteLine("CaseTrue(xxx,");
                })
                .Default((r) =>
                {
                    Console.WriteLine("SwitchInt Default(");
                });

            Console.WriteLine("SwitchInt Test={0}", Test);
        }

        public static void SwitchString()
        {
            string Test = "Karl";

            Test.Switch()
                .Case("Werner", (r) =>
                {
                    Console.WriteLine("Case(Werner, ");
                })
                .CaseIn("Werner", "Hugo", "Egon", (r) =>
                {
                    Console.WriteLine("CaseIn(Werner, Hugo, Egon,");
                })
                .CaseTrue(DateTime.Now.Second == 4711, (r) =>
                {
                    Console.WriteLine("CaseTrue(xxx,");
                })
                .CaseStartsWith("Name", (r) =>
                {
                    Console.WriteLine("CaseStartsWith(Name,");
                })
                .Default((r) =>
                {
                    Console.WriteLine("SwitchString Default(");
                });

            Console.WriteLine("SwitchString Test={0}", Test);
        }

        #endregion

        #region Log

        static void LogAll()
        {
            Action action = null;
            action.SafeInvoke();
            action = () =>
            {
                var j = 0;
                var i = 1 / j;
                Console.WriteLine(i);
            };

            // 1.
            action.SafeInvoke();

            // 2.
            Log.Try(() =>
                {
                    action.SafeInvoke();
                });

            // 3.
            action.Try();


            // Log..

            "Log.Message".LogMessage();
            "Log.Flow".LogFlow();
            string.Format("Hallo {0}", 1).LogHint();
        }

        #endregion

        #region Select
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

        public static void TestSelect()
        {
            string ResultOnCaseMessageA = "";
            string ResultOnCaseMessageB = "";
            Select select = new Select().OnOutput((text) =>
            {
                
            }).Case<MessageA>((obj, s) =>
            {
                ResultOnCaseMessageA = obj.A;
            }).Case<MessageB>((obj, s) =>
            {
                ResultOnCaseMessageB = obj.B;
            }).Case<MessageAB>((obj, s) =>
            {
                ResultOnCaseMessageA = obj.A;
                ResultOnCaseMessageB = obj.B;
            });

            select.InputUnitTest(new MessageA
            {
                A = "Hallo"
            });
            if (ResultOnCaseMessageA == "Hallo")
                Console.WriteLine("ok");
            else
                Console.WriteLine("error");
        }

        #endregion

    }

}
