<H1>EifelMono.Extensions</H1>

For your info it is better readable  

but the performance is an other thing.



<H3>Sample Switch!</H3>

```csharp
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
   
   :
      
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

   }

<h4>For more see  Samples and Unit Test</h4>

