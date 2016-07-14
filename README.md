<H1>EifelMono.Extensions</H1>

<H2>Sample Switch class</H2>

Switch case for classes and json string converting to classes 
to cases and output and then result...
json strings works with type names in the json string.

```c#
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
```

<H2>Sample Pipe Extension</H2>

Pipe Pipeping of void functions
```c#
    List<string> list1 = new List<string>
                    {
                        "list1.1",
                        "list1.2"
                    }
                    .Pipe(p => p.Add("list1.3"))
                    .Pipe(p => p.RemoveAt(0));

    List<string> list2 = new List<string>
                    {
                        "Hello World",
                     }
                    .Pipe((p) =>
                    {
                        for (var i = 0; i < 10; i++)
                            p.Add($"list2.{i} {DateTime.Now}");
                    }); 

    List<string> list3 = new List<string>
                    {   
                        "list3.1",
                        "list3.2",
                    }
                    .Pipe(p => p.AddRange(list1));                   

```

<H2>Sample Switch Extension</H2>

For your info it is better readable but the performance is an other thing.
```c#
   using EifelMono.Extensions;
   :
   {
       int TestValue = 1;
       int result = -1;
       TestValue.Switch()
           .Case(2, (p) =>
           {
               result = 0;
           })
           .CaseIn(3, 4, 5, (p) =>
           {
               result = 1;
           })
           .CaseInRange(10, 20, (p) =>
           {
               result = 2;
           })
           .Default((p) =>
           {
               result = 10;
           });
       Assert.IsTrue(result == 10);
   }
   :
   {
       int TestValue = 1;
       int result = -1;
       TestValue.Switch()
           .Case(1, (p) =>
           {
               result++;
               p.Continue();
           })
           .CaseIn(1, 2, 3, 4, (p) =>
           {
               result++;
               p.Continue();
           })
           .CaseInRange(1, 10, (p) =>
           {
               result++;
           })
           .Default((p) =>
           {
               result += 10;
           });
       Assert.IsTrue(result == 2);
   }
   :
   {
       string TestValue = "Hugo";
       int result = -1;
       TestValue.Switch()
           .Case("Bob", (p) =>
           {
               result = 0;
           })
           .CaseIn("Ben", "Leo", (p) =>
           {
               result = 1;
           })
           .CaseStartsWith("Hu")
           .And()
           .CaseEndsWith("O", (p) =>
           {
               result = 2;
           })
           .CaseStartsWith("Hug")
           .And()
           .CaseEndsWith("o", (p) =>
           {
               result = 3;
           })
           .Default((p) =>
           {
               result += 10;
           });
       Assert.IsTrue(result == 3);
   } 
   
```

<H2>Sample Select Extension</H2>
 
```c#
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

       var TestValue = new ClassC();

       if (TestValue is ClassA)
           Debug.WriteLine("ClassA");
       if (TestValue is ClassB)
          Debug.WriteLine("ClassB");
       if (TestValue is ClassC)
          Debug.WriteLine("ClassC");

       int count = 0;

       TestValue.Select()
           .CaseOn<ClassA>(
           (p, o) =>
           {
               Debug.WriteLine("o.A={0}", o.A);
               p.Continue();
               count += 1;
           })
           .CaseOn<ClassB>(
           (p, o) =>
           {
               Debug.WriteLine("o.A={0}", o.A);
               Debug.WriteLine("o.B={0}", o.B);
               p.Continue();
               count += 10;
           })
           .CaseOn<ClassC>((p, o) =>
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
   :
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
```

<H2>Sample In Extension</H2>

```c#   
   {
       public enum TestEnum
       {
           Karl,
           Heinz,
           Werner,
           Egon
       }
       TestEnum TestValue= TestEnum.Karl;
       if (TestValue.In(TestEnum.Karl, TestEnum.Heinz))
       {
       }
   }
   :
   {
       int TestValue= 1;
       if (TestValue.In(1,2,3))
       {
       }
   }
   :
   {   
       string Name= null; 
       if (Name.In("NameA", "NameB", ...));
       if (Name.InContains("NameA", "NameB", ...));
       if (Name.InStartsWith("NameA", "NameB", ...));
       if (Name.InEndsWith("NameA", "NameB", ...));
       if (Name.InLength(4, 5, ...));
   }
```

<H2>Sample Log Class</H2>
 
```c#
   {
	   try 
       {
           var j= 0;
           var i= 1/j;
           Console.WriteLine (i);
       }
       catch (Exception ex)
       {
           ex.LogException();
       }

       Log.Try(()=> {
      	   var j= 0;
           var i= 1/j;
           Console.WriteLine (i);
       });
       
       "Log.Message".LogMessage();
       "Log.Flow".LogFlow();
       string.Format("Hallo {0}", 1).LogHint();
   }
```

<H2>Sample First Class</H2>
 
```c#
   {
       public enum StatusBarStyle
       {
            Normal,
            Translucent,
            Dark,
            Light
       }
       // Before First
       bool CurrentStatusBarStyleFirst = true;
       StatusBarStyle CurrentStatusBarStyle = StatusBarStyle.Normal;
       StatusBarStyle NewStatusBarStyle = StatusBarStyle.Normal;
       if (CurrentStatusBarStyleFirst || CurrentStatusBarStyle!=NewStatusBarStyle)
       {
            CurrentStatusBarStyleFirst= false;
            CurrentStatusBarStyle= NewStatusBarStyle;

            switch (CurrentStatusBarStyle)
            {
                case StatusBarStyle.Normal:
                break;
            }
       }
       :
       // With First
       First<StatusBarStyle> CurrentStatusBarStyle = new First<StatusBarStyle>(StatusBarStyle.Normal);
       StatusBarStyle NewStatusBarStyle = StatusBarStyle.Normal;
       :
       if (CurrentStatusBarStyle.IsFirstOrNotEqual(NewStatusBarStyle))
       {
           switch (CurrentStatusBarStyle.Value)
           {
               case StatusBarStyle.Normal:
                    break;
               :
           }
       }
   }
```

<h3>For more see Sample's and Unit Test</h3>

