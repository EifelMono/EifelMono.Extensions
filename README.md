<H1>EifelMono.Extensions</H1>

For your info it is better readable  

but the performance is a other thing.


<H3>Sample Switch!</H3>

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

    Console.WriteLine("SwitchInt Test={0}", Test);


For more see  Samples and Unit Test

