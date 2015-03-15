EifelMono.Extensions
====================

For your info it is better readable
but the performance is the other thing.

Sample Switch!

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


For more see  Samples!

