<H1>EifelMono.Extensions</H1>

<H2>Sample Switch</H2>

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

<H2>Sample Select</H2>
 
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

<H2>Sample In</H2>

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
```

<H2>Sample Log</H2>
 
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

<h3>For more see Sample and Unit Test</h3>

