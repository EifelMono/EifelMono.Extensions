<H1>EifelMono.Extensions</H1>

For your info it is better readable  

but the performance is a other thing.

Sample Switch!

 	int Test = 1;

    Test.Switch()
        .Case(2, (p) =>
        {
            Console.WriteLine("Case(2, ");
        })
        .CaseIn(3, 4, 5, (p) =>
        {
            Console.WriteLine("CaseIn(3, 4, 5,");
        })
        .CaseInRange(10, 20, (p) =>
        {
            Console.WriteLine("CaseInRange(19, 20,");
        })
        .CaseTrue(DateTime.Now.Second == 4711, (p) =>
        {
            Console.WriteLine("CaseTrue(xxx,");
        })
        .Default((p) =>
        {
            Console.WriteLine("SwitchInt Default(");
        });

    Console.WriteLine("SwitchInt Test={0}", Test);


For more see  Samples!

